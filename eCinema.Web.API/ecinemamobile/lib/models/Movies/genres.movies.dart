import 'genres.dart';
part 'genres.movies.g.dart';

class GenresMovies {
  Genres? genre;
  GenresMovies();

  factory GenresMovies.fromJson(Map<String, dynamic> json) =>
      _$GenresMoviesFromJson(json);

  Map<String, dynamic> GenresMoviesToJson() => _$GenresMoviesToJson(this);
  @override
  String toString() {
    // TODO: implement toString
    return genre.toString();
  }
}
