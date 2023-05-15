import 'package:ecinemamobile/env.dart';
import 'package:ecinemamobile/models/Movies/movies.dart';
import 'package:ecinemamobile/providers/loyalty.club.dart';
import 'package:ecinemamobile/providers/movies.provider.dart';
import 'package:ecinemamobile/providers/reservation.provider.dart';
import 'package:ecinemamobile/providers/schedule.provider.dart';
import 'package:ecinemamobile/providers/user.provider.dart';
import 'package:ecinemamobile/screens/login.screen.dart';
import 'package:ecinemamobile/screens/loyalty.club.dart';
import 'package:ecinemamobile/screens/movies.screen.dart';
import 'package:ecinemamobile/screens/register.dart';
import 'package:ecinemamobile/screens/reservation.dart';
import 'package:ecinemamobile/screens/schedule.dart';
import 'package:ecinemamobile/screens/user.profile.dart';
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:provider/provider.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';

void main() async {
  await dotenv.load(fileName: "assets/.env");
  Stripe.publishableKey = dotenv.env['stripePublishableKey']!;

  runApp(
    MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => UserProvider()),
        ChangeNotifierProvider(create: (_) => MoviesProvider()),
        ChangeNotifierProvider(create: (_) => ScheduleProvider()),
        ChangeNotifierProvider(create: (_) => LoyaltyClubProvider()),
        ChangeNotifierProvider(create: (_) => ReservationProvider()),
      ],
      child: const MyApp(),
    ),
  );
  WidgetsFlutterBinding.ensureInitialized();
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
            titleLarge: TextStyle(fontSize: 18.0, fontStyle: FontStyle.italic),
          ),
        ),
        home: LoginScreen(),
        onGenerateRoute: (settings) {
          if (settings.name == MoviesListScreen.route) {
            return MaterialPageRoute(
                builder: ((context) => const MoviesListScreen()));
          }
          if (settings.name == RegisterScreen.route) {
            return MaterialPageRoute(
                builder: ((context) => const RegisterScreen()));
          }
          if (settings.name == UserProfile.route) {
            return MaterialPageRoute(
                builder: ((context) => const UserProfile()));
          }
          if (settings.name == LoginScreen.route) {
            return MaterialPageRoute(builder: ((context) => LoginScreen()));
          }
          if (settings.name == LoyaltyClubScreen.route) {
            return MaterialPageRoute(
                builder: ((context) => const LoyaltyClubScreen()));
          }
          var uri = Uri.parse(settings.name!);
          if (uri.pathSegments.length == 2 &&
              "/${uri.pathSegments.first}" == ScheduleScreen.routeName) {
            var id = uri.pathSegments[1];
            return MaterialPageRoute(builder: (context) => ScheduleScreen(id));
          }
          if (uri.pathSegments.length == 2 &&
              "/${uri.pathSegments.first}" == ReservationScreen.route) {
            var id = uri.pathSegments[1];
            return MaterialPageRoute(
                builder: (context) => ReservationScreen(id));
          }
        });
  }
}
