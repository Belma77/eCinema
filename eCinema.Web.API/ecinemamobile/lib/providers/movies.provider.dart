import 'package:ecinemamobile/models/Movies/movies.dart';

import 'base.provider.dart';

class MoviesProvider extends BaseProvider<Movies> {
  MoviesProvider() : super("Movies");

  @override
  Movies fromJson(data) {
    // TODO: implement fromJson
    return Movies.fromJson(data);
  }
}
