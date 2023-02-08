import 'package:json_annotation/json_annotation.dart';
import 'cast.dart';
part 'movies.directors.g.dart';

@JsonSerializable()
class DirectorsMovies extends Cast {
  Cast? director;

  DirectorsMovies() : super() {}
  factory DirectorsMovies.fromJson(Map<String, dynamic> json) =>
      _$DirectorsMoviesFromJson(json);

  Map<String, dynamic> DirectorsMoviesToJson() => _$DirectorsMoviesToJson(this);
  @override
  String toString() {
    // TODO: implement toString
    return director!.firstName! + " " + director!.lastName!;
  }
}
