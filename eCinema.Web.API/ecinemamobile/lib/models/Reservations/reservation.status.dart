enum ReservationStatusEnum {
  Booked,
  Canceled,
  Paid;

  String toJson() => name;
  static ReservationStatusEnum fromJson(String json) => values.byName(json);
}
