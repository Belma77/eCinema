part of 'movies.producer.dart';

ProducersMovies _$ProducersMoviesFromJson(Map<String, dynamic> json) =>
    ProducersMovies()..producer = Cast.fromJson(json['producer']);

Map<String, dynamic> _$ProducersMoviesToJson(ProducersMovies instance) =>
    <String, dynamic>{'': instance.producer};
