part of 'schedule.seat.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************
ScheduleSeat _$ScheduleSeatFromJson(Map<String, dynamic> json) => ScheduleSeat()
  ..scheduleId = json['scheduleId'] as int?
  ..seatId = json['seatId'] as int;

Map<String, dynamic> _$ScheduleSeatToJson(ScheduleSeat instance) =>
    <String, dynamic>{
      'scheduleId': instance.scheduleId,
      'seatId': instance.seatId
    };
