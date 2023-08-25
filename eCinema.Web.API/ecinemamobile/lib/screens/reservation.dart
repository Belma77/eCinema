import 'package:ecinemamobile/models/Payment/payment.dart';
import 'package:ecinemamobile/models/Reservations/reservation.dart';
import 'package:ecinemamobile/models/Reservations/reservation.status.dart';
import 'package:ecinemamobile/models/ScheduleSeats/schedule.seat.dart';
import 'package:ecinemamobile/screens/movies.screen.dart';
import 'package:ecinemamobile/screens/schedule.dart';
import 'package:ecinemamobile/utils/date.formatter.dart';
import 'package:ecinemamobile/utils/error.messages.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import '../models/Halls/hall.dart';
import '../models/Halls/hall.seats.dart';
import '../models/Schedules/schedule.dart';
import '../models/Seats/seat.dart';
import '../providers/reservation.provider.dart';
import '../providers/schedule.provider.dart';
import '../providers/user.provider.dart';
import 'package:ecinemamobile/assets/.env';

class ReservationScreen extends StatefulWidget {
  static const String route = "/ReservationScreen";
  String? id;
  ReservationScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<ReservationScreen> createState() => _ReservationScreenState();
}

class _ReservationScreenState extends State<ReservationScreen> {
  late ScheduleProvider? _scheduleProvider;
  late UserProvider? _userProvider;
  late ReservationProvider? _reservationProvider;
  static Map<String, dynamic>? paymentResponse;
  Map<String, dynamic>? paymentIntent;
  bool seatSelected = false;
  List<Seat>? seats;
  Hall? hall;
  int? scheduleId;
  int current = 0;
  int? customerId;
  List<int>? alreadyTaken = [];
  List<Seat>? chosenSeats = [];
  List<String> alpha =
      List.generate(26, (index) => String.fromCharCode(index + 65));
  Schedule? schedule;
  List<int> columns = [];
  double? price;

  @override
  void initState() {
    super.initState();
    ScheduleProvider();
    _scheduleProvider = context.read<ScheduleProvider>();
    loadSeats();
    _userProvider = context.read<UserProvider>();
    _reservationProvider = context.read<ReservationProvider>();
  }

  Future loadSeats() async {
    scheduleId = int.parse(widget.id!);
    var tmpData = await _scheduleProvider?.getById(scheduleId!);
    if (mounted) {
      setState(() {
        hall = tmpData?.hall;
        seats = tmpData?.hall?.seats;
        schedule = tmpData;
        columns = List<int>.generate(hall!.numberOfColumns!, (i) => i + 1);
        if (schedule!.scheduleSeats!.isNotEmpty) {
          for (var seat in tmpData!.scheduleSeats!) {
            alreadyTaken?.add(seat.seatId!);
          }
        }
      });
    }
  }

  Future reserveTickets(Reservation reservation) async {
    ReservationProvider();
    try {
      await _reservationProvider?.insert(reservation);
      if (reservation.status == ReservationStatusEnum.Booked) {
        showMessage("Succesfully reserved");
      } else {
        showMessage("Succesfully paid");
      }
    } catch (err) {
      showMessage(err.toString());
    }
  }

  void pay() async {
    if (chosenSeats!.isNotEmpty) {
      price = (schedule!.ticketPrice! * 100) * chosenSeats!.length;
      var round = price!.round().toString();
      try {
        paymentResponse =
            await _reservationProvider!.createPaymentIntent(round);
        await displayPaymentSheet();
      } on StripeException catch (e) {
        showMessage(ErrorMessages.paymentFailed);
      } catch (err) {
        showMessage(err.toString());
      }
    } else {
      showMessage("Seats not chosen, payment not succeded");
    }
  }

  displayPaymentSheet() async {
    try {
      await Stripe.instance.presentPaymentSheet().then((value) async {
        await makeReservation(ReservationStatusEnum.Paid);
      });
    } on StripeException catch (e) {
      showMessage(ErrorMessages.paymentCanceled);
    } catch (err) {
      showMessage(ErrorMessages.paymentFailed);
    }
    setState(() {
      paymentIntent = null;
    });
  }

  Future makeReservation(ReservationStatusEnum status) async {
    if (chosenSeats!.isNotEmpty) {
      int? numberOfTickets = chosenSeats?.length;
      price = numberOfTickets! * schedule!.ticketPrice!;
      List<ScheduleSeat> seats = [];
      for (var seat in chosenSeats!) {
        var add = ScheduleSeat();
        add.scheduleId = scheduleId;
        add.seatId = seat.id;
        seats.add(add);
      }
      Reservation reservation;
      if (status == ReservationStatusEnum.Paid) {
        var decode = Payment.fromJson(paymentResponse!);
        reservation = Reservation(
            schedule!.id, numberOfTickets, seats, price, status, decode.id);
      } else {
        reservation =
            Reservation(schedule!.id, numberOfTickets, seats, price, status);
      }
      ReservationProvider();
      try {
        await _reservationProvider?.insert(reservation);
        if (reservation.status == ReservationStatusEnum.Booked) {
          showMessage("Succesfully reserved");
        } else {
          showMessage("Succesfully paid");
        }
      } catch (err) {
        showMessage(err.toString());
      }
    } else {
      showMessage("Seats not chosen, reservation not succeded");
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      resizeToAvoidBottomInset: false,
      appBar: AppBar(
        title: const Center(
          child: Text("eCinema"),
        ),
      ),
      body: SafeArea(child: SingleChildScrollView(child: _build())),
    );
  }

  Widget _build() {
    if (seats == null) {
      return Align(
        alignment: Alignment.center,
        child: Container(
            width: 100,
            height: 100,
            child: const Center(
              child: Text(
                "Loading...",
                style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
              ),
            )),
      );
    } else {
      return Container(
          height: MediaQuery.of(context).size.height,
          width: MediaQuery.of(context).size.width,
          child: Column(children: [
            Padding(
              padding: const EdgeInsets.all(10.0),
              child: Container(
                margin: EdgeInsets.only(top: 10),
                child: const Text(
                  "Please select your seats",
                  style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                ),
              ),
            ),
            SingleChildScrollView(
              child: Padding(
                padding: const EdgeInsets.all(8.0),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                  children: [
                    Padding(
                        padding: EdgeInsets.all(8),
                        child: Container(
                            decoration: BoxDecoration(
                                color: Colors.grey,
                                border: Border.all(
                                    color: Colors.grey,
                                    width: 1.0,
                                    style: BorderStyle.solid),
                                borderRadius: BorderRadius.circular(4)),
                            width: 20,
                            height: 20)),
                    const Text("Taken seats"),
                    Padding(
                        padding: const EdgeInsets.all(8),
                        child: Container(
                            decoration: BoxDecoration(
                                color: Colors.yellow,
                                border: Border.all(
                                    color: Colors.grey,
                                    width: 1.0,
                                    style: BorderStyle.solid),
                                borderRadius: BorderRadius.circular(4)),
                            width: 20,
                            height: 20)),
                    const Text("Free seats"),
                    Padding(
                        padding: const EdgeInsets.all(8),
                        child: Container(
                            decoration: BoxDecoration(
                                color: Colors.red,
                                border: Border.all(
                                    color: Colors.grey,
                                    width: 1.0,
                                    style: BorderStyle.solid),
                                borderRadius: BorderRadius.circular(4)),
                            width: 20,
                            height: 20)),
                    const Text("Selected seats"),
                  ],
                ),
              ),
            ),
            Container(
              height: 183,
              width: double.infinity,
              child: Padding(
                padding: const EdgeInsets.all(5.0),
                child: Row(
                  children: [
                    Column(children: [
                      Expanded(
                        child: Container(
                            width: 30,
                            height: 170,
                            child: ListView.builder(
                              itemCount: hall?.numberOfRows,
                              scrollDirection: Axis.vertical,
                              itemBuilder: (BuildContext context, int index) {
                                return Padding(
                                  padding:
                                      const EdgeInsets.fromLTRB(8, 8, 8, 9),
                                  child: Container(
                                      width: 3,
                                      child: Text(
                                        alpha[index],
                                        style: const TextStyle(fontSize: 15),
                                      )),
                                );
                              },
                            )),
                      )
                    ]),
                    Expanded(
                      child: Container(
                        child: GridView.count(
                          crossAxisCount: 10,
                          children: List.generate(seats!.length, (index) {
                            return InkWell(
                                onTap: () {
                                  if (alreadyTaken!
                                      .contains(seats![index].id)) {
                                    showMessage("Seat already taken");
                                  } else if (chosenSeats!
                                      .contains(seats![index])) {
                                    setState(() {
                                      chosenSeats!.remove(seats![index]);
                                    });
                                  } else if (alreadyTaken!.length ==
                                      seats!.length) {
                                    showMessage("All seats already taken");
                                  } else {
                                    setState(() {
                                      chosenSeats!.add(seats![index]);
                                    });
                                  }
                                },
                                child: Container(
                                  decoration: BoxDecoration(
                                      border: Border.all(
                                          color: Colors.grey,
                                          width: 1.0,
                                          style: BorderStyle.solid),
                                      borderRadius: BorderRadius.circular(4),
                                      color: (chosenSeats!
                                              .contains(seats![index]))
                                          ? Colors.red
                                          : (alreadyTaken!
                                                  .contains(seats![index].id))
                                              ? Colors.grey
                                              : Colors.yellow),
                                  margin: const EdgeInsets.all(5),
                                ));
                          }),
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            ),
            Container(
                width: double.infinity,
                height: 40,
                margin: const EdgeInsets.only(left: 30),
                child: ListView.builder(
                  itemCount: hall?.numberOfColumns,
                  scrollDirection: Axis.horizontal,
                  itemBuilder: (BuildContext context, int index) {
                    return Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: Container(
                          width: 20,
                          child: Center(
                              child: Text(columns[index].toString(),
                                  style: const TextStyle(fontSize: 16)))),
                    );
                  },
                )),
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Container(
                  margin: const EdgeInsets.only(top: 15),
                  child: const Text(
                    "Confirm your reservation",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                  )),
            ),
            Column(
              children: [
                Padding(
                  padding: const EdgeInsets.fromLTRB(20, 8, 8, 8),
                  child: Align(
                    alignment: Alignment.topLeft,
                    child: Text(
                      "Movie: ${schedule!.movie!.title}",
                      style: const TextStyle(
                          fontSize: 16, fontWeight: FontWeight.bold),
                    ),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.fromLTRB(20, 8, 8, 8),
                  child: Align(
                    alignment: Alignment.topLeft,
                    child: Text(
                      "Ticket price: ${schedule!.ticketPrice.toString()}",
                      style: const TextStyle(
                          fontSize: 16, fontWeight: FontWeight.bold),
                    ),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.fromLTRB(20, 8, 8, 8),
                  child: Align(
                    alignment: Alignment.topLeft,
                    child: Text(
                      "Number of tickets: ${chosenSeats?.length}",
                      style: const TextStyle(
                          fontSize: 16, fontWeight: FontWeight.bold),
                    ),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.fromLTRB(20, 8, 8, 8),
                  child: Align(
                    alignment: Alignment.topLeft,
                    child: Text(
                      "Date: ${formatDate(schedule!.date!)}",
                      style: const TextStyle(
                          fontSize: 16, fontWeight: FontWeight.bold),
                    ),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.fromLTRB(20, 8, 8, 8),
                  child: Align(
                    alignment: Alignment.topLeft,
                    child: Text(
                      "Start time: ${formatTime(schedule!.startTime!)}",
                      style: const TextStyle(
                          fontSize: 16, fontWeight: FontWeight.bold),
                    ),
                  ),
                ),
                const Padding(
                  padding: EdgeInsets.fromLTRB(20, 8, 8, 8),
                  child: Align(
                    alignment: Alignment.topLeft,
                    child: Text(
                      "Selected seats: ",
                      style:
                          TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
                    ),
                  ),
                ),
                Padding(
                  padding: EdgeInsets.fromLTRB(0, 8, 8, 5),
                  child: Container(
                    width: double.infinity,
                    height: 35,
                    margin: const EdgeInsets.only(left: 20),
                    child: Align(
                      alignment: Alignment.topLeft,
                      child: ListView.builder(
                        itemCount: chosenSeats?.length,
                        scrollDirection: Axis.horizontal,
                        itemBuilder: (BuildContext context, int index) {
                          return Padding(
                            padding: const EdgeInsets.fromLTRB(0, 8, 8, 9),
                            child: Center(
                              child: Text("${chosenSeats![index]},",
                                  style: const TextStyle(fontSize: 16)),
                            ),
                          );
                        },
                      ),
                    ),
                  ),
                ),
                const SizedBox(
                  height: 10,
                ),
                Container(
                  width: double.infinity,
                  child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        Padding(
                          padding: const EdgeInsets.all(10.0),
                          child: Container(
                            //width: 130,
                            decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(10),
                                color: Colors.blue),
                            child: Padding(
                              padding: const EdgeInsets.all(8.0),
                              child: InkWell(
                                onTap: () {
                                  try {
                                    makeReservation(
                                        ReservationStatusEnum.Booked);
                                  } catch (e) {
                                    showMessage(e.toString());
                                  }
                                },
                                child: const Center(
                                    child: Text(
                                  "Reserve tickets",
                                  style: TextStyle(
                                      fontSize: 15,
                                      fontWeight: FontWeight.bold),
                                )),
                              ),
                            ),
                          ),
                        ),
                        Padding(
                          padding: const EdgeInsets.all(8.0),
                          child: Container(
                            //width: 130,
                            decoration: BoxDecoration(
                                borderRadius: BorderRadius.circular(10),
                                color: Colors.blue),
                            child: Padding(
                              padding: const EdgeInsets.all(8.0),
                              child: InkWell(
                                onTap: () {
                                  try {
                                    pay();
                                  } catch (e) {
                                    showMessage(e.toString());
                                  }
                                },
                                child: const Center(
                                    child: Text("Buy tickets",
                                        style: TextStyle(
                                            fontSize: 15,
                                            fontWeight: FontWeight.bold))),
                              ),
                            ),
                          ),
                        ),
                      ]),
                ),
              ],
            )
          ]));
    }
  }

  showMessage(String message) {
    return showDialog(
        context: context,
        builder: (BuildContext context) => AlertDialog(
              title: const Text("Message"),
              content: Text(message),
              actions: [
                TextButton(
                    child: const Text("Ok"),
                    onPressed: () => Navigator.pushNamed(
                          context,
                          MoviesListScreen.route,
                        ))
              ],
            ));
  }
}
