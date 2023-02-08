import '../models/Schedules/schedule.dart';
import 'base.provider.dart';

class ScheduleProvider extends BaseProvider<Schedule> {
  ScheduleProvider() : super("Schedule");

  @override
  Schedule fromJson(data) {
    return Schedule.fromJson(data);
  }
}
