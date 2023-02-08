import 'dart:convert';
import 'dart:ffi';
import 'package:ecinemamobile/models/Schedules/projection.dart';
import 'package:json_annotation/json_annotation.dart';

import '../../utils/date.formatter.dart';
import '../Movies/movies.dart';
part 'schedule.g.dart';

@JsonSerializable()
class Schedule {
  int? id;
  Projection? movie;
  DateTime? date;
  String? dayOfWeek;
  DateTime? startTime;

  Schedule() {}
  factory Schedule.fromJson(Map<String, dynamic> json) =>
      _$ScheduleFromJson(json);

  /// Connect the generated [_$ProductToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ScheduleToJson(this);
}
