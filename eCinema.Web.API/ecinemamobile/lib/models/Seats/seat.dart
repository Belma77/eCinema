import 'package:json_annotation/json_annotation.dart';
part 'seat.g.dart';

@JsonSerializable()
class Seat {
  int? id;
  int? column;
  String? row;

  factory Seat.fromJson(Map<String, dynamic> json) => _$SeatFromJson(json);
  Seat();
  Map<String, dynamic> toJson() => _$SeatToJson(this);

  @override
  String toString() {
    return column.toString() + row!;
  }
}
