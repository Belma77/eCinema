part of 'reservation.dart';

Reservation _$ReservationFromJson(Map<String, dynamic> json) {
  return Reservation(json['scheduleId'] as int?,
      json['numberOfTickets'] as int?, null, json['price'] as double, null);
}

Map<String, dynamic> _$ReservationToJson(Reservation instance) {
  var obj = <String, dynamic>{
    'scheduleId': instance.scheduleId,
    'numberOfTickets': instance.numberOfTickets,
    'scheduleSeats': instance.scheduleSeats,
    'price': instance.price,
    'status': instance.status!.index
  };
  return obj;
}
