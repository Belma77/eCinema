import 'package:json_annotation/json_annotation.dart';

import '../Seats/seat.dart';
part 'hall.seats.g.dart';

@JsonSerializable()
class HallSeat {
  int? seatId;
  Seat? seat;

  HallSeat();
  factory HallSeat.fromJson(Map<String, dynamic> json) =>
      _$HallSeatFromJson(json);

  Map<String, dynamic> HallSeattoJson() => _$HallSeatToJson(this);
}
