part of 'genres.movies.dart';

GenresMovies _$GenresMoviesFromJson(Map<String, dynamic> json) =>
    GenresMovies()..genre = Genres.fromJson(json['genre']);

Map<String, dynamic> _$GenresMoviesToJson(GenresMovies instance) =>
    <String, dynamic>{'genre': instance.genre};
