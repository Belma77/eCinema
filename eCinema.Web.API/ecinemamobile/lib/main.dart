import 'package:ecinemamobile/models/Movies/movies.dart';
import 'package:ecinemamobile/providers/movies.provider.dart';
import 'package:ecinemamobile/providers/schedule.provider.dart';
import 'package:ecinemamobile/providers/user.provider.dart';
import 'package:ecinemamobile/screens/loginScreen.dart';
import 'package:ecinemamobile/screens/movies.screen.dart';
import 'package:ecinemamobile/screens/schedule.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(
    MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => UserProvider()),
        ChangeNotifierProvider(create: (_) => MoviesProvider()),
        ChangeNotifierProvider(create: (_) => ScheduleProvider())
      ],
      child: const MyApp(),
    ),
  );
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        title: 'eCinema',
        theme: ThemeData(
          primarySwatch: Colors.blue,
          textButtonTheme: TextButtonThemeData(
              style: TextButton.styleFrom(
                  foregroundColor: Colors.black,
                  textStyle: const TextStyle(
                      fontSize: 20,
                      fontWeight: FontWeight.bold,
                      fontStyle: FontStyle.italic))),

          // Define the default `TextTheme`. Use this to specify the default
          // text styling for headlines, titles, bodies of text, and more.
          textTheme: const TextTheme(
            displayLarge:
                TextStyle(fontSize: 60.0, fontWeight: FontWeight.bold),
            titleLarge: TextStyle(fontSize: 26.0, fontStyle: FontStyle.italic),
          ),
        ),
        home: LoginScreen(),
        onGenerateRoute: (settings) {
          if (settings.name == MoviesListScreen.route) {
            return MaterialPageRoute(
                builder: ((context) => const MoviesListScreen()));
          }
          var uri = Uri.parse(settings.name!);
          if (uri.pathSegments.length == 2 &&
              "/${uri.pathSegments.first}" == ScheduleScreen.routeName) {
            var id = uri.pathSegments[1];
            return MaterialPageRoute(builder: (context) => ScheduleScreen(id));
          }
        });
  }
}
