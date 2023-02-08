import 'package:json_annotation/json_annotation.dart';
import 'cast.dart';
part 'movies.actors.g.dart';

@JsonSerializable()
class ActorsMovies extends Cast {
  Cast? actor;

  ActorsMovies() : super() {}
  factory ActorsMovies.fromJson(Map<String, dynamic> json) =>
      _$ActorsMoviesFromJson(json);

  Map<String, dynamic> ActorsMoviesToJson() => _$ActorsMoviesToJson(this);
  @override
  String toString() {
    // TODO: implement toString
    return actor!.firstName! + " " + actor!.lastName!;
  }
}
