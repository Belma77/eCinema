import 'package:ecinemamobile/screens/register.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';
import '../models/Authorization/authorization.dart';
import '../providers/movies.provider.dart';
import '../providers/schedule.provider.dart';
import '../providers/user.provider.dart';
import '../utils/validator.dart';
import 'movies.screen.dart';

class LoginScreen extends StatefulWidget {
  static const route = "Login";
  const LoginScreen({super.key});

  @override
  State<LoginScreen> createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  late ScheduleProvider _scheduleProvider;
  bool _obscureText = true;
  final _formKey = GlobalKey<FormState>();

  login() async {
    if (_formKey.currentState!.validate()) {
      ScheduleProvider();
      Authorization.username = _usernameController.text;
      Authorization.password = _passwordController.text;
      try {
        await _scheduleProvider.get();
        Navigator.pushNamed(context, MoviesListScreen.route);
      } catch (e) {
        rethrow;
      }
    }
  }

  @override
  void initState() {
    super.initState();
    _obscureText = true;
  }

  @override
  Widget build(BuildContext context) {
    _scheduleProvider = Provider.of<ScheduleProvider>(context, listen: false);

    return Scaffold(
        appBar: AppBar(
          toolbarHeight: 100,
          title: const Text("Welcome to eCinema"),
          automaticallyImplyLeading: false,
        ),
        body: SafeArea(
            child: Form(
          key: _formKey,
          child: Column(mainAxisAlignment: MainAxisAlignment.center, children: [
            Container(
              margin: const EdgeInsets.fromLTRB(30, 10, 30, 10),
              child: SizedBox(
                child: TextFormField(
                  controller: _usernameController,
                  validator: Validator.validateName,
                  keyboardType: TextInputType.text,
                  style: const TextStyle(
                    fontSize: 18.0,
                    height: 1.0,
                    color: Colors.black,
                  ),
                  decoration: const InputDecoration(
                    hintText: "Username",
                    prefixIcon: Icon(Icons.person),
                    enabledBorder: UnderlineInputBorder(
                      borderSide: BorderSide(
                          width: 2, color: Color.fromARGB(255, 131, 178, 215)),
                    ),
                  ),
                ),
              ),
            ),
            Container(
              margin: const EdgeInsets.fromLTRB(30, 0, 30, 10),
              child: TextFormField(
                controller: _passwordController,
                obscureText: _obscureText,
                validator: Validator.validatePassword,
                keyboardType: TextInputType.text,
                style: const TextStyle(
                    fontSize: 18.0, height: 1.0, color: Colors.black),
                decoration: InputDecoration(
                  hintText: "Password",
                  prefixIcon: const Icon(Icons.lock),
                  enabledBorder: const UnderlineInputBorder(
                    borderSide: BorderSide(
                        width: 2, color: Color.fromARGB(255, 115, 170, 215)),
                  ),
                  suffixIcon: IconButton(
                    icon: _obscureText == true
                        ? const Icon(Icons.visibility_off)
                        : const Icon(Icons.visibility),
                    onPressed: () {
                      setState(
                        () {
                          _obscureText = !_obscureText;
                        },
                      );
                    },
                  ),
                ),
              ),
            ),
            Container(
              height: 50,
              margin: const EdgeInsets.fromLTRB(30, 20, 30, 20),
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10), color: Colors.blue),
              child: InkWell(
                onTap: () async {
                  try {
                    var response = await login();
                  } catch (e) {
                    showMessage(e.toString());
                  }
                },
                child: const Center(
                  child: Text(
                    "Login",
                    style: TextStyle(
                      fontSize: 20,
                      color: Colors.white,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ),
              ),
            ),
            InkWell(
                onTap: () {
                  Navigator.pushNamed(context, RegisterScreen.route);
                },
                child: const Text(
                  "No account? Click to register here",
                  style: TextStyle(
                      decoration: TextDecoration.underline, fontSize: 14),
                ))
          ]),
        )));
  }

  showMessage(String message) {
    return showDialog(
        context: context,
        builder: (BuildContext context) => AlertDialog(
              title: const Text("Message"),
              content: Text(message),
              actions: [
                TextButton(
                    child: const Text("Ok"),
                    onPressed: () => Navigator.pop(context))
              ],
            ));
  }
}
