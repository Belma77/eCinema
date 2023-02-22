import 'dart:core';
import 'dart:core';
import 'package:json_annotation/json_annotation.dart';

import '../Seats/seat.dart';
part 'hall.g.dart';

@JsonSerializable()
class Hall {
  int? noOfHall;
  int? numberOfSeats;
  int? numberOfRows;
  int? numberOfColumns;
  List<Seat>? seats;

  Hall(this.noOfHall, this.numberOfSeats, this.numberOfRows,
      this.numberOfColumns,
      [this.seats]);
  factory Hall.fromJson(Map<String, dynamic> json) => _$HallFromJson(json);

  Map<String, dynamic> HalltoJson() => _$HallToJson(this);
}
