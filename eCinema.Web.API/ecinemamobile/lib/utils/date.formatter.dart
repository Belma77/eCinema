import 'package:intl/intl.dart';
import 'package:json_annotation/json_annotation.dart';

class CustomDateTimeConverter implements JsonConverter<DateTime, String> {
  const CustomDateTimeConverter();

  @override
  DateTime fromJson(String json) {
    if (json.contains(".")) {
      json = json.substring(0, json.length - 1);
    }

    return DateTime.parse(json);
  }

  @override
  String toJson(DateTime json) => json.toIso8601String();
}

String formatDate(DateTime date) {
  if (dynamic == null) {
    return "";
  }
  // DateTime tempDate = new DateFormat("yyyy-MM-dd hh:mm:ss").parse(date);
  // var f = DateFormat.MEd();
  var f = DateFormat.jm();

  return f.format(date);
}
