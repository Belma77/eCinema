import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:provider/provider.dart';

import '../models/Authorization/authorization.dart';
import '../models/Users/customer.insert.dart';
import '../models/Users/user.dart';
import '../providers/movies.provider.dart';
import '../providers/schedule.provider.dart';
import '../providers/user.provider.dart';
import '../utils/error.messages.dart';
import '../utils/validator.dart';
import 'login.screen.dart';
import 'movies.screen.dart';

class RegisterScreen extends StatefulWidget {
  const RegisterScreen({super.key});
  static const route = "/Register";

  @override
  State<RegisterScreen> createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  TextEditingController _firstNameController = TextEditingController();
  TextEditingController _lastNameController = TextEditingController();
  TextEditingController _emailController = TextEditingController();
  TextEditingController _phoneController = TextEditingController();
  final _formKey = GlobalKey<FormState>();

  String? firstName;
  String? lastName;
  String? phone;
  String? username;
  String? password;
  String? email;
  bool _obscureText = true;

  late UserProvider _userProvider;
  @override
  void initState() {
    super.initState();
    _userProvider = context.read<UserProvider>();
  }

  Future registerUser() async {
    UserProvider();
    CustomerInsert customer =
        CustomerInsert(firstName, lastName, phone, email, username, password);
    if (_formKey.currentState!.validate()) {
      await _userProvider.register(customer);
      Navigator.pushNamed(context, LoginScreen.route);
    }
  }

  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of<UserProvider>(context, listen: false);
    return Scaffold(
      appBar: AppBar(
        toolbarHeight: 100,
        title: const Text("Welcome to eCinema"),
        automaticallyImplyLeading: false,
      ),
      body: SafeArea(
        child: SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.fromLTRB(25, 30, 25, 30),
            child: Expanded(
              child: Form(
                key: _formKey,
                child: Column(
                  children: [
                    Container(
                      child: const Align(
                        alignment: Alignment.topCenter,
                        child: Text(
                          "Register your account",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 20),
                        ),
                      ),
                    ),
                    Container(
                      margin: const EdgeInsets.all(10),
                      child: TextFormField(
                          controller: _firstNameController,
                          onChanged: (String value) {
                            firstName = value;
                          },
                          validator: Validator.validateName,
                          keyboardType: TextInputType.text,
                          style: const TextStyle(
                              fontSize: 18.0, height: 2.0, color: Colors.black),
                          decoration: const InputDecoration(
                            labelText: 'First name',
                            labelStyle: TextStyle(fontSize: 15),
                            hintText: "First name",
                            enabledBorder: UnderlineInputBorder(
                              borderSide: BorderSide(
                                  width: 1,
                                  color: Color.fromARGB(255, 131, 178, 215)),
                            ),
                          )),
                    ),
                    Container(
                      margin: const EdgeInsets.all(10),
                      child: TextFormField(
                          controller: _lastNameController,
                          keyboardType: TextInputType.text,
                          onChanged: (String value) {
                            lastName = value;
                          },
                          validator: Validator.validateName,
                          style: const TextStyle(
                              fontSize: 18.0, height: 1.5, color: Colors.black),
                          decoration: const InputDecoration(
                            labelStyle: TextStyle(fontSize: 15),
                            labelText: 'Last name',
                            hintText: "Last name",
                            enabledBorder: UnderlineInputBorder(
                              borderSide: BorderSide(
                                  width: 1,
                                  color: Color.fromARGB(255, 131, 178, 215)),
                            ),
                          )),
                    ),
                    Container(
                      margin: const EdgeInsets.all(10),
                      child: TextFormField(
                          controller: _emailController,
                          onChanged: (String value) {
                            email = value;
                          },
                          validator: Validator.validateEmail,
                          keyboardType: TextInputType.emailAddress,
                          style: const TextStyle(
                              fontSize: 18.0, height: 1.5, color: Colors.black),
                          decoration: const InputDecoration(
                            labelText: 'Email',
                            labelStyle: TextStyle(fontSize: 15),
                            hintText: "Email",
                            enabledBorder: UnderlineInputBorder(
                              borderSide: BorderSide(
                                  width: 1,
                                  color: Color.fromARGB(255, 131, 178, 215)),
                            ),
                          )),
                    ),
                    Container(
                      margin: const EdgeInsets.all(10),
                      child: TextFormField(
                          controller: _phoneController,
                          onChanged: (String value) {
                            phone = value;
                          },
                          validator: Validator.validatePhone,
                          keyboardType: TextInputType.phone,
                          style: const TextStyle(
                              fontSize: 18.0, height: 1.5, color: Colors.black),
                          decoration: const InputDecoration(
                            labelStyle: TextStyle(fontSize: 15),
                            labelText: 'Phone',
                            hintText: "Phone",
                            enabledBorder: UnderlineInputBorder(
                              borderSide: BorderSide(
                                  width: 1,
                                  color: Color.fromARGB(255, 131, 178, 215)),
                            ),
                          )),
                    ),
                    Container(
                      margin: const EdgeInsets.all(10),
                      child: TextFormField(
                          controller: _usernameController,
                          onChanged: (String value) {
                            username = value;
                          },
                          validator: Validator.validateName,
                          keyboardType: TextInputType.text,
                          style: const TextStyle(
                              fontSize: 18.0, height: 1.5, color: Colors.black),
                          decoration: const InputDecoration(
                            labelText: 'Username',
                            labelStyle: TextStyle(fontSize: 15),
                            hintText: "Username",
                            enabledBorder: UnderlineInputBorder(
                              borderSide: BorderSide(
                                  width: 1,
                                  color: Color.fromARGB(255, 131, 178, 215)),
                            ),
                          )),
                    ),
                    Container(
                      margin: const EdgeInsets.all(10),
                      child: TextFormField(
                          controller: _passwordController,
                          obscureText: _obscureText,
                          onChanged: (String value) {
                            password = value;
                          },
                          validator: Validator.validatePassword,
                          keyboardType: TextInputType.text,
                          style: const TextStyle(
                              fontSize: 18.0, height: 1.5, color: Colors.black),
                          decoration: InputDecoration(
                            labelText: 'Password',
                            labelStyle: TextStyle(fontSize: 15),
                            hintText: "Password",
                            enabledBorder: const UnderlineInputBorder(
                              borderSide: BorderSide(
                                  width: 1,
                                  color: Color.fromARGB(255, 131, 178, 215)),
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
                          )),
                    ),
                    Container(
                      height: 50,
                      //width: 200,
                      margin: const EdgeInsets.fromLTRB(10, 10, 10, 20),
                      decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(10),
                          color: Colors.blue),
                      child: InkWell(
                        onTap: () {
                          try {
                            registerUser();
                          } catch (err) {
                            showMessage(err.toString());
                          }
                        },
                        child: const Center(
                          child: Text(
                            "Register",
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
                          Navigator.pushNamed(context, LoginScreen.route);
                        },
                        child: const Text(
                          "Already have an account? Click to sign in here",
                          style: TextStyle(
                              decoration: TextDecoration.underline,
                              fontSize: 14),
                        ))
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
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
                    onPressed: () => Navigator.pushNamed(
                          context,
                          MoviesListScreen.route,
                        ))
              ],
            ));
  }
}
