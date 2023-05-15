import 'package:ecinemamobile/models/Halls/hall.seats.dart';
import 'package:ecinemamobile/models/Reservations/reservation.status.dart';
import '../ScheduleSeats/schedule.seat.dart';
import '../Schedules/schedule.dart';
part 'reservation.g.dart';

class Reservation {
  int? scheduleId;
  int? numberOfTickets;
  List<ScheduleSeat>? scheduleSeats;
  double? price;
  ReservationStatusEnum? status;
  String? paymentID;
  Reservation(this.scheduleId, this.numberOfTickets, this.scheduleSeats,
      this.price, this.status,
      [this.paymentID]);
  factory Reservation.fromJson(Map<String, dynamic> json) =>
      _$ReservationFromJson(json);

  Map<String, dynamic> toJson() => _$ReservationToJson(this);
}
