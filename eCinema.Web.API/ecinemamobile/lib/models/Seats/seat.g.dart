part of 'seat.dart';
// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Seat _$SeatFromJson(Map<String, dynamic> json) => Seat()
  ..id = json['id'] as int?
  ..row = json['row'] as String?
  ..column = json['column'] as int;

Map<String, dynamic> _$SeatToJson(Seat instance) => <String, dynamic>{
      'id': instance.id,
      'row': instance.row,
      'column': instance.column,
    };
