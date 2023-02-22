part of 'hall.dart';

Hall _$HallFromJson(Map<String, dynamic> json) {
  List<Seat> _seats = [];

  var seats = json['seats'] as List;
  if (seats != null) {
    _seats = seats.map((x) => Seat.fromJson(x)).toList();
    return Hall(json['noOfHall'] as int, json['numberOfSeats'] as int,
        json['numberOfRows'] as int, json['numberOfColumns'] as int, _seats);
  } else {
    return Hall(json['noOfHall'] as int, json['numberOfSeats'] as int,
        json['numberOfRows'] as int, json['numberOfColumns'] as int);
  }
}

Map<String, dynamic> _$HallToJson(Hall instance) => <String, dynamic>{
      'noOfHall': instance.noOfHall,
      'numberOfSeats': instance.numberOfSeats,
      'hallSeats': instance.seats,
      'numberOfRows': instance.numberOfRows,
      'numberOfColumns': instance.numberOfColumns
    };
