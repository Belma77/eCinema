import 'package:json_annotation/json_annotation.dart';
import 'cast.dart';
part 'movies.producers.g.dart';

@JsonSerializable()
class ProducersMovies extends Cast {
  Cast? producer;

  ProducersMovies() : super() {}
  factory ProducersMovies.fromJson(Map<String, dynamic> json) =>
      _$ProducersMoviesFromJson(json);

  Map<String, dynamic> ProducersMoviesToJson() => _$ProducersMoviesToJson(this);
  @override
  String toString() {
    // TODO: implement toString
    return producer!.firstName! + " " + producer!.lastName!;
  }
}
