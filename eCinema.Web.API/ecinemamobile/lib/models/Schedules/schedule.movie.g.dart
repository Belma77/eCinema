part of 'schedule.movie.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ScheduleMovie _$ScheduleMovieFromJson(Map<String, dynamic> json) {
  return ScheduleMovie(
      json['id'] as int,
      const CustomDateTimeConverter().fromJson(json['date'] as String),
      json['dayOfWeek'] as String,
      const CustomDateTimeConverter().fromJson(json['startTime'] as String),
      Hall.fromJson(json['hall']));
}

Map<String, dynamic> _$ScheduleMovieToJson(ScheduleMovie instance) =>
    <String, dynamic>{
      'id': instance.id,
      'date': instance.date,
      'startTime': instance.startTime,
      'dayOfWeek': instance.dayOfWeek,
      'hall': instance.hall
    };
