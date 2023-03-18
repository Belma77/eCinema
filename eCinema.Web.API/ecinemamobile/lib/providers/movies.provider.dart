import 'dart:convert';

import 'package:ecinemamobile/models/Movies/movies.dart';
import 'package:ecinemamobile/models/Schedules/projection.dart';

import '../env.dart';
import 'base.provider.dart';

class MoviesProvider extends BaseProvider<Movies> {
  MoviesProvider() : super("Movies");
  final _baseUrl =
      const String.fromEnvironment("baseUrl", defaultValue: baseUrl);
  final _endpoint = "Movies";

  @override
  Movies fromJson(data) {
    return Movies.fromJson(data);
  }

  Future<List<Projection>> getRecommendation(int id, String path) async {
    var url = "$_baseUrl$_endpoint/$id/$path";
    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response = await http!.get(uri, headers: headers);
    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data
          .map((x) => Projection.fromJson(x))
          .cast<Projection>()
          .toList();
    } else {
      throw Exception("Ups.. something went wrong");
    }
  }
}
