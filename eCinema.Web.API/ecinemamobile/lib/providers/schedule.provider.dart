import 'dart:convert';

import 'package:ecinemamobile/models/ScheduleSeats/schedule.seat.dart';
import 'package:ecinemamobile/models/Schedules/projection.dart';

import '../env.dart';
import '../models/Schedules/schedule.dart';
import 'base.provider.dart';

class ScheduleProvider extends BaseProvider<Schedule> {
  ScheduleProvider() : super("Schedule");
  final _baseUrl =
      const String.fromEnvironment("baseUrl", defaultValue: baseUrl);
  final _endpoint = "Schedules";
  @override
  Schedule fromJson(data) {
    return Schedule.fromJson(data);
  }
}
