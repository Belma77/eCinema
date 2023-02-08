part of 'schedule.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Schedule _$ScheduleFromJson(Map<String, dynamic> json) => Schedule()
  ..id = json['id'] as int?
  ..movie = Projection.fromJson(json['movie'])
  ..date = const CustomDateTimeConverter().fromJson(json['date'] as String)
  ..startTime =
      const CustomDateTimeConverter().fromJson(json['startTime'] as String)
  ..dayOfWeek = json['dayOfWeek'] as String;

Map<String, dynamic> _$ScheduleToJson(Schedule instance) => <String, dynamic>{
      'id': instance.id,
      'movie': instance.movie,
      'date': instance.date,
      'startTime': instance.startTime,
      'dayOfWeek': instance.dayOfWeek
    };
