import 'dart:convert';
import 'dart:io';

import 'package:ecinemamobile/models/Authorization/authorization.dart';
import 'package:ecinemamobile/screens/login.screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:http/http.dart';
import 'package:image_picker/image_picker.dart';
import 'package:provider/provider.dart';

import '../models/Users/user.dart';
import '../providers/user.provider.dart';

class UserProfile extends StatefulWidget {
  static const String route = "/UserProfile";
  const UserProfile({super.key});

  @override
  State<UserProfile> createState() => _UserProfileState();
}

class _UserProfileState extends State<UserProfile> {
  File? _pickedImage;
  late UserProvider? _userProvider;
  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _phoneController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();

  String? firstName;
  String? lastName;
  String? username;
  String? phone;
  String? email;

  Customer? user;
  @override
  void initState() {
    super.initState();
    _userProvider = context.read<UserProvider>();
    getUser();
  }

  Future getImage() async {
    final image = await ImagePicker().pickImage(source: ImageSource.gallery);
    if (image == null) {
      return;
    }
    final imageTmp = File(image.path);
    setState(() {
      _pickedImage = imageTmp;
    });
  }

  Future getUser() async {
    var tmpData = await _userProvider?.getUser();
    setState(() {
      user = tmpData;
      FillControllers();
    });
  }

  Future Edit() async {
    Customer edit = Customer.paramterless();
    edit.firstName = firstName;
    edit.lastName = lastName;
    edit.phone = phone;
    edit.email = email;
    edit.username = Authorization.username;
    try {
      await _userProvider!.update(user!.id!, edit);
      Navigator.pop(context);
    } catch (err) {}
  }

  Future Delete() async {
    await _userProvider!.delete(user!.id!);
  }

  FillControllers() {
    firstName = user!.firstName!;
    _firstNameController.text = firstName!;

    lastName = user!.lastName!;
    _lastNameController.text = lastName!;

    phone = user!.phone!;
    _phoneController.text = phone!;

    email = user!.email!;
    _emailController.text = email!;

    email = user!.email!;
    _emailController.text = email!;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Edit your profile")),
      body: SafeArea(
        child: SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.fromLTRB(25, 20, 25, 20),
            child: Expanded(
              child: Column(
                children: [
                  Container(
                    child: Align(
                      alignment: Alignment.topRight,
                      child: ElevatedButton(
                        onPressed: () {
                          Edit();
                        },
                        child: const Text("Save changes"),
                      ),
                    ),
                  ),
                  Container(
                    margin: const EdgeInsets.all(10),
                    child: TextField(
                        controller: _firstNameController,
                        onChanged: (String value) {
                          firstName = value;
                        },
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
                    child: TextField(
                        controller: _lastNameController,
                        onChanged: (String value) {
                          lastName = value;
                        },
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
                    child: TextField(
                        controller: _emailController,
                        onChanged: (String value) {
                          email = value;
                        },
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
                    child: TextField(
                        controller: _phoneController,
                        onChanged: (String value) {
                          phone = value;
                        },
                        style: const TextStyle(
                            fontSize: 18.0, height: 1.5, color: Colors.black),
                        decoration: const InputDecoration(
                          labelText: 'Phone',
                          labelStyle: TextStyle(fontSize: 15),
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
                      child: _pickedImage != null
                          ? Image.file(
                              _pickedImage!,
                              fit: BoxFit.fill,
                            )
                          : null),
                  Container(
                    child: Align(
                      alignment: Alignment.bottomCenter,
                      child: ElevatedButton(
                          onPressed: getImage, child: const Text("Pick image")),
                    ),
                  ),
                  Container(
                    child: Align(
                        alignment: Alignment.bottomCenter,
                        child: ElevatedButton(
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.red, // Background color
                            ),
                            onPressed: () {
                              showDialog(
                                  context: context,
                                  builder: (BuildContext ctx) {
                                    return AlertDialog(
                                      title: const Text('Please Confirm'),
                                      content: const Text(
                                          'Are you sure to delete your account?'),
                                      actions: [
                                        TextButton(
                                            onPressed: () {
                                              Delete();
                                              Navigator.of(context).pop();
                                            },
                                            child: const Text('Yes')),
                                        TextButton(
                                            onPressed: () {
                                              Navigator.of(context).pop();
                                            },
                                            child: const Text('No'))
                                      ],
                                    );
                                  });
                            },
                            child: const Text("DELETE ACCOUNT"))),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
