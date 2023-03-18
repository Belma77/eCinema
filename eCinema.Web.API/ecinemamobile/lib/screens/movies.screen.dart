import 'dart:convert';
import 'dart:io';

import 'package:ecinemamobile/models/Schedules/projection.dart';
import 'package:ecinemamobile/models/Schedules/schedule.dart';
import 'package:ecinemamobile/screens/schedule.dart';
import 'package:ecinemamobile/screens/user.profile.dart';
import 'package:ecinemamobile/widgets/drawer.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../providers/projection.provider.dart';
import '../providers/schedule.provider.dart';
import 'package:darq/darq.dart';

class MoviesListScreen extends StatefulWidget {
  const MoviesListScreen({super.key});
  static const String route = "/MoviesList";
  @override
  State<MoviesListScreen> createState() => _MoviesListScreenState();
}

class _MoviesListScreenState extends State<MoviesListScreen> {
  ScheduleProvider? _scheduleProvider = null;
  List<Schedule> data = [];
  TextEditingController _searchController = TextEditingController();
  int current = 0;
  @override
  void initState() {
    super.initState();
    _scheduleProvider = context.read<ScheduleProvider>();
    loadData(items[current]);
  }

  Future loadData(String? day) async {
    ScheduleProvider();
    data = [];
    var tmpData = await _scheduleProvider?.get({'DayOfWeek': day});
    setState(() {
      var result = tmpData!.toList();
      for (var item in result) {
        if (!data.contains(item)) {
          data.add(item);
        }
      }
    });
  }

  List<String> items = [
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
        appBar: AppBar(
            title: const Center(
          child: Text(
            "eCinema",
          ),
        )),
        drawer: DrawerWidget(),
        body: SafeArea(
          child: Padding(
            padding: const EdgeInsets.all(10),
            child: Column(children: [
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: SizedBox(
                  height: 50,
                  width: double.maxFinite,
                  child: ListView.builder(
                    itemCount: items.length,
                    scrollDirection: Axis.horizontal,
                    itemBuilder: (BuildContext context, int index) {
                      return GestureDetector(
                        onTap: () {
                          setState(() {
                            current = index;
                            loadData(items[current]);
                          });
                        },
                        child: Container(
                          margin: EdgeInsets.all(5),
                          width: 80,
                          height: 45,
                          decoration: BoxDecoration(
                              color:
                                  current == index ? Colors.blue : Colors.white,
                              border: Border.all(
                                  color: Colors.grey,
                                  width: 1.0,
                                  style: BorderStyle.solid),
                              borderRadius: BorderRadius.circular(10)),
                          child: Center(
                              child: Text(
                            items[index],
                            style: const TextStyle(fontWeight: FontWeight.bold),
                          )),
                        ),
                      );
                    },
                  ),
                ),
              ),
              Expanded(child: _buildMoviesList()),
            ]),
          ),
        ));
  }

  Widget _buildProjectionCard(Schedule item) {
    return Card(
        clipBehavior: Clip.antiAlias,
        shape: RoundedRectangleBorder(
          side: const BorderSide(
            color: Colors.grey,
          ),
          borderRadius: BorderRadius.circular(12),
        ),
        child: Column(children: [
          Padding(
            padding: const EdgeInsets.all(10),
            child: Row(
              children: [
                Container(
                  width: 200,
                  height: 300,
                  child: ClipRRect(
                    borderRadius: BorderRadius.circular(12.0),
                    child: Image.memory(base64Decode(item.movie!.poster!)),
                  ),
                ),
                Expanded(
                  child: Container(
                    padding: EdgeInsets.fromLTRB(5, 10, 5, 5),
                    height: 300,
                    child: Column(
                      children: [
                        Text(
                          item.movie!.title.toString() + "\n",
                          style: const TextStyle(
                            fontSize: 16,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        Align(
                          alignment: Alignment.topLeft,
                          child: Text(
                            "Duration: ${item.movie!.duration.toString()}"
                            " min"
                            "\n",
                            style: const TextStyle(fontSize: 15),
                          ),
                        ),
                        Align(
                          alignment: Alignment.topLeft,
                          child: Text(
                            "Release year: ${item.movie!.releaseYear.toString()}"
                            "\n",
                            style: const TextStyle(
                              fontSize: 15,
                            ),
                          ),
                        ),
                        Align(
                          alignment: Alignment.topLeft,
                          child: Text(
                            "Country: ${item.movie!.country.toString()}\n",
                            style: const TextStyle(
                              fontSize: 15,
                            ),
                          ),
                        ),
                        const SizedBox(
                          height: 50,
                        ),
                        Align(
                          alignment: Alignment.bottomCenter,
                          child: InkWell(
                            onTap: () {
                              Navigator.pushNamed(context,
                                  "${ScheduleScreen.routeName}/${item.movie!.id}");
                            },
                            child: const Text(
                              "Click for more projection details",
                              style: TextStyle(fontWeight: FontWeight.bold),
                            ),
                          ),
                        )
                      ],
                    ),
                  ),
                ),
              ],
            ),
          ),
        ]));
  }

  Widget _buildMoviesList() {
    if (data.isEmpty) {
      return Align(
        alignment: Alignment.center,
        child: Container(
            child: const Text(
          "Loading...",
          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
        )),
      );
    }
    return Container(
      child: ListView.builder(
        itemCount: data.length,
        itemBuilder: (context, index) {
          return _buildProjectionCard(data[index]);
        },
      ),
    );
  }
}
