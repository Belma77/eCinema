import 'package:json_annotation/json_annotation.dart';
import 'cast.dart';
part 'movies.writers.g.dart';

@JsonSerializable()
class WritersMovies extends Cast {
  Cast? writer;

  WritersMovies() : super() {}
  factory WritersMovies.fromJson(Map<String, dynamic> json) =>
      _$WritersMoviesFromJson(json);

  Map<String, dynamic> WritersMoviesToJson() => _$WritersMoviesToJson(this);
  @override
  String toString() {
    return writer!.firstName! + " " + writer!.lastName!;
  }
}
