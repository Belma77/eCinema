import 'dart:convert';
import 'dart:core';
import 'package:ecinemamobile/models/Schedules/projection.dart';
import 'package:json_annotation/json_annotation.dart';

import '../../utils/date.formatter.dart';
import '../Halls/hall.dart';
import '../Movies/movies.dart';
import '../ScheduleSeats/schedule.seat.dart';
import '../Seats/seat.dart';
part 'schedule.g.dart';

@JsonSerializable()
class Schedule {
  int id;
  DateTime? date;
  String? dayOfWeek;
  DateTime? startTime;
  Hall? hall;
  double? ticketPrice;
  Projection? movie;
  List<ScheduleSeat>? scheduleSeats;
  Schedule(this.id, this.date, this.dayOfWeek, this.startTime, this.hall,
      this.ticketPrice,
      [this.movie, this.scheduleSeats]) {}
  factory Schedule.fromJson(Map<String, dynamic> json) =>
      _$ScheduleFromJson(json);

  Map<String, dynamic> toJson() => _$ScheduleToJson(this);

  @override
  bool operator ==(Object item) {
    return identical(this, item) ||
        item is Schedule &&
            runtimeType == item.runtimeType &&
            movie!.title == item.movie!.title;
  }

  @override
  int get hashCode => movie!.title.hashCode;
}
