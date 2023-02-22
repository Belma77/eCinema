part 'scheduleseat.g.dart';

class ScheduleSeat {
  int? scheduleId;
  int? seatId;
  ScheduleSeat();
  factory ScheduleSeat.fromJson(Map<String, dynamic> json) =>
      _$ScheduleSeatFromJson(json);

  Map<String, dynamic> toJson() => _$ScheduleSeatToJson(this);
}
