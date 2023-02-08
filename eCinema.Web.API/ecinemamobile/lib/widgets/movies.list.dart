import 'package:ecinemamobile/models/Movies/movies.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../providers/movies.provider.dart';

class MoviesList extends StatefulWidget {
  const MoviesList({super.key});
  static const String route = "/MoviesList";
  @override
  State<MoviesList> createState() => _MoviesListState();
}

class _MoviesListState extends State<MoviesList> {
  MoviesProvider? _moviesProvider = null;
  List<Movies> data = [];
  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _moviesProvider = context.read<MoviesProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _moviesProvider?.get(null);
    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Container(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Container(
                height: 200,
                color: Colors.amber,
                width: 200,
                child: GridView(
                  gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                      crossAxisCount: 1,
                      childAspectRatio: 4 / 3,
                      crossAxisSpacing: 20,
                      mainAxisSpacing: 30),
                  scrollDirection: Axis.vertical,
                  children: _buildMoviesList(),
                )),
          ],
        ),
      ),
    );
  }

  List<Widget> _buildMoviesList() {
    if (data.length == 0) {
      return [Text("Loading...")];
    }

    List<Widget> list = data
        .map((x) => Container(
              child: Column(
                children: [
                  Text(x.title ?? ""),
                  Text(x.country ?? ""),
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
