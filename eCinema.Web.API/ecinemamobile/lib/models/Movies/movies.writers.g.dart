part of 'movies.writers.dart';

WritersMovies _$WritersMoviesFromJson(Map<String, dynamic> json) =>
    WritersMovies()..writer = Cast.fromJson(json['writer']);

Map<String, dynamic> _$WritersMoviesToJson(WritersMovies instance) =>
    <String, dynamic>{'writer': instance.writer};
