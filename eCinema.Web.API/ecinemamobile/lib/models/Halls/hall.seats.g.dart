part of 'hall.seats.dart';

HallSeat _$HallSeatFromJson(Map<String, dynamic> json) => HallSeat()
  ..seatId = json['seatId'] as int
  ..seat = Seat.fromJson(json['seat']);
Map<String, dynamic> _$HallSeatToJson(HallSeat instance) =>
    <String, dynamic>{'seatId': instance.seatId, 'seat': instance.seat};
