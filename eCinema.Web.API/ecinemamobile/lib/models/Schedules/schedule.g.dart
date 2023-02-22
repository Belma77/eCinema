part of 'schedule.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Schedule _$ScheduleFromJson(Map<String, dynamic> json) {
  List<ScheduleSeat> _scheduleSeats = [];
  if (json['scheduleSeats'] != null) {
    var scheduleSeats = json['scheduleSeats'] as List;
    _scheduleSeats =
        scheduleSeats.map((e) => ScheduleSeat.fromJson(e)).toList();
  }
  if (json['movie'] != null) {
    return Schedule(
        json['id'] as int,
        const CustomDateTimeConverter().fromJson(json['date'] as String),
        json['dayOfWeek'] as String,
        const CustomDateTimeConverter().fromJson(json['startTime'] as String),
        Hall.fromJson(json['hall']),
        json['ticketPrice'] as double,
        Projection.fromJson(json['movie']),
        _scheduleSeats);
  } else {
    return Schedule(
        json['id'] as int,
        const CustomDateTimeConverter().fromJson(json['date'] as String),
        json['dayOfWeek'] as String,
        const CustomDateTimeConverter().fromJson(json['startTime'] as String),
        Hall.fromJson(json['hall']),
        json['ticketPrice'] as double,
        null,
        _scheduleSeats);
  }
}

Map<String, dynamic> _$ScheduleToJson(Schedule instance) => <String, dynamic>{
      'id': instance.id,
      'movie': instance.movie,
      'date': instance.date,
      'startTime': instance.startTime,
      'dayOfWeek': instance.dayOfWeek,
      'ticketPrice': instance.ticketPrice
    };
