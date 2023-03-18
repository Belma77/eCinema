import '../../utils/date.formatter.dart';
import '../Halls/hall.dart';
import 'package:json_annotation/json_annotation.dart';
part 'schedule.movie.g.dart';

@JsonSerializable()
class ScheduleMovie {
  int id;
  DateTime? date;
  String? dayOfWeek;
  DateTime? startTime;
  //Hall? hall;

  ScheduleMovie(this.id, this.date, this.dayOfWeek, this.startTime) {}
  factory ScheduleMovie.fromJson(Map<String, dynamic> json) =>
      _$ScheduleMovieFromJson(json);

  Map<String, dynamic> toJson() => _$ScheduleMovieToJson(this);
}
