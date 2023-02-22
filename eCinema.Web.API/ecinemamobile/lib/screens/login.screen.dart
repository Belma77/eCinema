import 'package:ecinemamobile/widgets/movies.list.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../models/Authorization/authorization.dart';
import '../providers/movies.provider.dart';
import '../providers/schedule.provider.dart';
import '../providers/user.provider.dart';
import 'movies.screen.dart';

class LoginScreen extends StatelessWidget {
  static const route = "Login";
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  late ScheduleProvider _scheduleProvider;
  LoginScreen({super.key});

  @override
  Widget build(BuildContext context) {
    _scheduleProvider = Provider.of<ScheduleProvider>(context, listen: false);
    return Scaffold(
      appBar: AppBar(
        toolbarHeight: 100,
        title: const Text("Welcome to eCinema"),
      ),
      body: SafeArea(
        child: Column(mainAxisAlignment: MainAxisAlignment.center, children: [
          Container(
            margin: EdgeInsets.fromLTRB(40, 10, 40, 10),
            child: SizedBox(
              child: TextField(
                controller: _usernameController,
                style: const TextStyle(
                    fontSize: 20.0, height: 1.5, color: Colors.black),
                decoration: const InputDecoration(
                  enabledBorder: UnderlineInputBorder(
                    borderSide: BorderSide(
                        width: 1, color: Color.fromARGB(255, 131, 178, 215)),
                  ),
                ),
              ),
            ),
          ),
          Container(
            margin: EdgeInsets.fromLTRB(40, 0, 40, 10),
            child: TextField(
              controller: _passwordController,
              style: const TextStyle(
                  fontSize: 20.0, height: 1.5, color: Colors.black),
              decoration: const InputDecoration(
                enabledBorder: UnderlineInputBorder(
                  borderSide: BorderSide(
                      width: 1, color: Color.fromARGB(255, 115, 170, 215)),
                ),
              ),
            ),
          ),
          Container(
            height: 50,
            margin: const EdgeInsets.fromLTRB(40, 20, 40, 10),
            decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10), color: Colors.blue),
            child: InkWell(
              onTap: () async {
                try {
                  Authorization.username = _usernameController.text;
                  Authorization.password = _passwordController.text;
                  await _scheduleProvider.get();
                  Navigator.pushNamed(context, MoviesListScreen.route);
                } catch (e) {
                  showDialog(
                      context: context,
                      builder: (BuildContext context) => AlertDialog(
                            title: Text("Error"),
                            content: Text(e.toString()),
                            actions: [
                              TextButton(
                                child: Text("Ok"),
                                onPressed: () => Navigator.pop(context),
                              )
                            ],
                          ));
                }
              },
              child: const Center(
                child: Text(
                  "Login",
                  style:
                      TextStyle(height: 2, fontSize: 20, color: Colors.black),
                ),
              ),
            ),
          ),
        ]),
      ),
    );
  }
}
