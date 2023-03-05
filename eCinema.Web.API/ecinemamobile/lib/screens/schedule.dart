import 'dart:convert';
import 'dart:math';
import 'package:ecinemamobile/models/Movies/movies.dart';
import 'package:ecinemamobile/providers/schedule.provider.dart';
import 'package:ecinemamobile/screens/reservation.dart';
import 'package:ecinemamobile/utils/date.formatter.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../models/Schedules/schedule.dart';
import '../models/Schedules/schedule.movie.dart';
import '../providers/movies.provider.dart';
import '../utils/image.convertor.dart';

class ScheduleScreen extends StatefulWidget {
  ScheduleScreen(this.id, {Key? key}) : super(key: key);
  static const String routeName = "/schedule_details";
  String id;

  @override
  State<ScheduleScreen> createState() => _ScheduleScreenState();
}

class _ScheduleScreenState extends State<ScheduleScreen> {
  late ScheduleProvider? _scheduleProvider;
  late MoviesProvider? _moviesProvider;
  Movies? item;
  int? MovieId;
  List<ScheduleMovie>? schedules;
  List<Schedule>? items;
  List<Movies>? movies;

  int? current;
  @override
  void initState() {
    super.initState();
    MoviesProvider();
    _moviesProvider = context.read<MoviesProvider>();
    loadData();
    _scheduleProvider = context.read<ScheduleProvider>();
    // loadSchedule();
    //getRecommendations();
  }

  Future loadData() async {
    MovieId = int.parse(widget.id);
    var tmpData = await _moviesProvider?.getById(MovieId!);
    setState(() {
      item = tmpData!;
      schedules = item!.schedules;
      filterSchedule(days[0]);
    });
  }

  Future filterSchedule(String day) async {
    setState(() {
      schedules = item!.schedules!.where((x) => x.dayOfWeek == day).toList();
    });
  }

  Future getRecommendations() async {
    var tmpData =
        await _moviesProvider!.getRecommendation(MovieId!, "Recommend");
    setState(() {
      movies = tmpData;
    });
  }

  List<String> days = [
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday",
    "Sunday",
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      resizeToAvoidBottomInset: false,
      appBar: AppBar(
        title: const Center(
          child: Text("eCinema"),
        ),
      ),
      body: SafeArea(
        child: SingleChildScrollView(
            child: Column(children: [
          builtProjectionInfo(),
        ])),
      ),
      /*  bottomNavigationBar: BottomNavigationBar(
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.home),
            label: "Home",
          ),
          BottomNavigationBarItem(
              icon: Icon(Icons.shopping_bag_outlined), label: 'Buy tickets')
        ],
        backgroundColor: Colors.blue,
        fixedColor: Colors.white,
        unselectedItemColor: Colors.red,
      ), */
    );
  }

  Widget builtProjectionInfo() {
    if (item == null) {
      return const Align(
          alignment: Alignment.center,
          child: Text(
            "Loading..",
            style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
          ));
    }
    return Container(
      width: MediaQuery.of(context).size.width,
      child: Card(
          color: Colors.grey[50],
          clipBehavior: Clip.antiAlias,
          shape: RoundedRectangleBorder(
            side: const BorderSide(
              color: Colors.grey,
            ),
            borderRadius: BorderRadius.circular(24),
          ),
          child: Column(children: [
            Padding(
              padding: const EdgeInsets.all(8),
              child: Container(
                width: double.infinity,
                height: 350,
                child: ClipRRect(
                  borderRadius: BorderRadius.circular(8.0),
                  child: Image.memory(
                    base64Decode(item!.poster!),
                    fit: BoxFit.fill,
                  ),
                ),
              ),
            ),
            Container(
                margin: const EdgeInsets.all(10),
                child: Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: Expanded(
                    child: Column(children: [
                      Align(
                        alignment: Alignment.center,
                        child: Text(
                          item!.title.toString() + "\n",
                          style: const TextStyle(
                            fontSize: 25,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                      Align(
                        alignment: Alignment.topLeft,
                        child: Text(
                          "Duration: ${item!.duration.toString()}"
                          " min"
                          "\n",
                          style: const TextStyle(
                            fontSize: 18,
                          ),
                        ),
                      ),
                      Align(
                        alignment: Alignment.topLeft,
                        child: Text(
                          "Release year: ${item!.releaseYear.toString()}\n",
                          style: const TextStyle(
                            fontSize: 18,
                          ),
                        ),
                      ),
                      Align(
                        alignment: Alignment.topLeft,
                        child: builtGenresMovies(),
                      ),
                      Align(
                        alignment: Alignment.topLeft,
                        child: Text(
                          "Country: ${item!.country.toString()}\n",
                          style: const TextStyle(
                            fontSize: 18,
                          ),
                        ),
                      ),
                      Align(
                        alignment: Alignment.topLeft,
                        child: Text(
                          "Synopsis: ${item!.synopsis.toString()}\n",
                          style: const TextStyle(
                            fontSize: 18,
                          ),
                        ),
                      ),
                      Align(
                        alignment: Alignment.topLeft,
                        child: builtActorsMovies(),
                      ),
                      Align(
                        alignment: Alignment.topLeft,
                        child: builtDirectorsMovies(),
                      ),
                      Align(
                        alignment: Alignment.topLeft,
                        child: builtWritersMovies(),
                      ),
                      Align(
                        alignment: Alignment.topLeft,
                        child: builtProducersMovies(),
                      ),
                    ]),
                  ),
                )),
            buildProjectionSchedule(),
            // buildRecommendation(),
          ])),
    );
  }

  Widget buildProjectionSchedule() {
    if (schedules == null) {
      return const Text("");
    }

    return Padding(
      padding: const EdgeInsets.all(10),
      child: Column(children: [
        const Center(
          child: Text(
            "Click on a date to reserve tickets",
            style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.all(8.0),
          child: Container(
            height: 50,
            width: double.maxFinite,
            child: ListView.builder(
              itemCount: days.length,
              scrollDirection: Axis.horizontal,
              itemBuilder: (BuildContext context, int index) {
                return GestureDetector(
                    onTap: () {
                      setState(() {
                        current = index;
                        filterSchedule(days[index]);
                      });
                    },
                    child: Container(
                      margin: const EdgeInsets.all(5),
                      width: 80,
                      height: 45,
                      decoration: BoxDecoration(
                          color: current == index ? Colors.blue : Colors.grey,
                          border: Border.all(
                              color: Colors.grey,
                              width: 1.0,
                              style: BorderStyle.solid),
                          borderRadius: BorderRadius.circular(10)),
                      child: Center(
                        child: Text(days[index]),
                      ),
                    ));
              },
            ),
          ),
        ),
        buildScheduleTimes(),
      ]),
    );
  }

  Widget buildScheduleTimes() {
    if (schedules == null) return const Text("");
    return Column(
      children: [
        Padding(
          padding: const EdgeInsets.all(8.0),
          child: Container(
            height: 50,
            width: double.maxFinite,
            child: ListView.builder(
              itemCount: schedules!.length,
              scrollDirection: Axis.horizontal,
              itemBuilder: (BuildContext context, int index) {
                return GestureDetector(
                    onTap: () {
                      setState(() {
                        Navigator.pushNamed(context,
                            "${ReservationScreen.route}/${schedules![index].id}");
                      });
                    },
                    child: Container(
                        margin: const EdgeInsets.all(5),
                        width: 80,
                        height: 45,
                        decoration: BoxDecoration(
                            color: Colors.white,
                            border: Border.all(
                                color: Colors.grey,
                                width: 1.0,
                                style: BorderStyle.solid),
                            borderRadius: BorderRadius.circular(10)),
                        child: Center(
                            child: Text(
                                formatTime(schedules![index].startTime!)))));
              },
            ),
          ),
        )
      ],
    );
  }

  Widget builtActorsMovies() {
    if (item!.actorsMovies == null) {
      return const Text("");
    }

    return Expanded(
      child: Text(
        "Actors:  ${item!.actorsMovies!.join(',')}"
        "\n",
        style: const TextStyle(
          fontSize: 18,
        ),
      ),
    );
  }

  Widget builtDirectorsMovies() {
    if (item!.directorsMovies == null) {
      return Text("");
    }

    return Expanded(
        child: Text(
      "Directors:  ${item!.directorsMovies!.join(',')}"
      "\n",
      style: const TextStyle(
        fontSize: 18,
      ),
    ));
  }

  Widget builtWritersMovies() {
    if (item!.writersMovies == null) {
      return const Text("");
    }

    return Expanded(
      child: Text(
        "Writers:  ${item!.writersMovies!.join(',')}"
        "\n",
        style: const TextStyle(
          fontSize: 18,
        ),
      ),
    );
  }

  Widget builtProducersMovies() {
    if (item!.producersMovies == null) {
      return Text("");
    }

    return Expanded(
      child: Text(
        "Producers:  ${item!.producersMovies!.join(',')}"
        "\n",
        style: const TextStyle(
          fontSize: 18,
        ),
      ),
    );
  }

  Widget builtGenresMovies() {
    if (item?.genresMovies == null) {
      return const Text("");
    }

    return Expanded(
      child: Text(
        "Genres:  ${item!.genresMovies.join(', ')}"
        "\n",
        style: const TextStyle(
          fontSize: 18,
        ),
      ),
    );
  }

  Widget buildRecommendation() {
    if (movies == null) {
      return Align(
        alignment: Alignment.center,
        child: Container(
            child: const Text(
          "Loading...",
          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
        )),
      );
    }
    return Column(
      children: [
        const Center(
          child: Text(
            "You might be interested in these movies",
            style: TextStyle(fontSize: 15, fontWeight: FontWeight.bold),
          ),
        ),
        Padding(
          padding: const EdgeInsets.all(8.0),
          child: Container(
            height: 300,
            width: double.maxFinite,
            child: ListView.builder(
              itemCount: movies!.length,
              scrollDirection: Axis.horizontal,
              itemBuilder: (BuildContext context, int index) {
                return Column(
                  children: [
                    Row(children: [
                      Padding(
                          padding: const EdgeInsets.all(8.0),
                          child: Container(
                            // color: Colors.white,
                            height: 250,
                            width: 170,
                            child: Image.memory(
                              base64Decode(movies![index].poster!),
                              fit: BoxFit.fill,
                            ),
                          ))
                    ]),
                    Text(
                      movies![index].title!,
                      style: const TextStyle(
                          fontSize: 15, fontWeight: FontWeight.bold),
                    )
                  ],
                );
              },
            ),
          ),
        ),
      ],
    );
  }
}
