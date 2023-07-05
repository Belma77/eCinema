import 'package:ecinemamobile/models/Authorization/authorization.dart';
import 'package:ecinemamobile/models/Payment/payment.dart';
import 'package:ecinemamobile/models/Users/customer.type.dart';
import 'package:ecinemamobile/models/Users/user.loyalty.dart';
import 'package:ecinemamobile/screens/movies.screen.dart';
import 'package:ecinemamobile/utils/error.messages.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:http/io_client.dart';
import 'package:provider/provider.dart';

import '../models/Users/user.dart';
import '../providers/loyalty.club.dart';
import '../providers/user.provider.dart';
import '../utils/validator.dart';

class LoyaltyClubScreen extends StatefulWidget {
  static const String route = "LoyaltyClub";
  const LoyaltyClubScreen({super.key});

  @override
  State<LoyaltyClubScreen> createState() => _LoyaltyClubScreenState();
}

class _LoyaltyClubScreenState extends State<LoyaltyClubScreen> {
  late LoyaltyClubProvider? _loyaltyClubProvider;
  late UserProvider? _userProvider;
  IOClient? http;
  static Map<String, dynamic>? paymentIntent;
  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();
  final TextEditingController _idController = TextEditingController();
  final TextEditingController _cityController = TextEditingController();
  final TextEditingController _phoneController = TextEditingController();
  final TextEditingController _emailController = TextEditingController();
  String? firstName;
  String? lastName;
  String? identificationNumber;
  String? phone;
  String? city;
  String? email;
  Customer? user;
  final _formKey = GlobalKey<FormState>();

  @override
  void initState() {
    super.initState();
    _userProvider = context.read<UserProvider>();
    getUser();
    _loyaltyClubProvider = context.read<LoyaltyClubProvider>();
  }

  Future getUser() async {
    var tmpData = await _userProvider?.getUser();
    setState(() {
      user = tmpData;
    });
  }

  makePayment() async {
    if (_formKey.currentState!.validate()) {
      var response = await _loyaltyClubProvider!.alreadyLoyal(user!.id!);
      if (response == true) {
        throw Exception("Customer already added to loyalty club!");
      }
      try {
        paymentIntent = await _loyaltyClubProvider!.createPaymentIntent('2395');
        await displayPaymentSheet();
      } on StripeException catch (e) {
        showDialog(
          context: context,
          builder: (_) => const AlertDialog(
            content: Text(ErrorMessages.paymentCanceled),
          ),
        );
      } catch (err) {
        rethrow;
      }
    } else {}
  }

  joinLoyalty() async {
    LoyalCard loyalty = LoyalCard();
    loyalty.customerId = user!.id;
    loyalty.firstName = firstName;
    loyalty.lastName = lastName;
    loyalty.email = email;
    loyalty.phone = phone;
    loyalty.city = city;
    loyalty.username = Authorization.username;
    loyalty.identificationNumber = identificationNumber;
    loyalty.paymentID = Payment.fromJson(paymentIntent!).id;
    _loyaltyClubProvider = LoyaltyClubProvider();
    try {
      await _loyaltyClubProvider!.insert(loyalty);
      showDialog(
        context: context,
        builder: (_) => AlertDialog(
          content: Text("Payment succesful"),
          actions: [
            TextButton(
                child: const Text("Ok"),
                onPressed: () => Navigator.pop(context))
          ],
        ),
      );
    } catch (err) {
      rethrow;
    }
  }

  displayPaymentSheet() async {
    try {
      await Stripe.instance.presentPaymentSheet().then((value) async {
        try {
          await joinLoyalty();
        } catch (err) {
          paymentIntent = null;
          rethrow;
        }
      });
    } catch (err) {
      rethrow;
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Join our loyalty club")),
      body: SafeArea(
        child: SingleChildScrollView(
          child: Padding(
            padding: const EdgeInsets.fromLTRB(25, 30, 25, 20),
            child: Expanded(
              child: Form(
                key: _formKey,
                child: Column(
                  children: [
                    Container(
                      child: const Align(
                        alignment: Alignment.topCenter,
                        child: Text(
                          "Fill in informations and become member of our loyalty club",
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
                          onChanged: (String value) {
                            lastName = value;
                          },
                          validator: Validator.validateName,
                          keyboardType: TextInputType.text,
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
                          controller: _idController,
                          onChanged: (String value) {
                            identificationNumber = value;
                          },
                          validator: Validator.validateName,
                          keyboardType: TextInputType.text,
                          style: const TextStyle(
                              fontSize: 18.0, height: 1.5, color: Colors.black),
                          decoration: const InputDecoration(
                            labelStyle: TextStyle(fontSize: 15),
                            labelText: 'Identification number',
                            hintText: "Identification number",
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
                          controller: _cityController,
                          onChanged: (String value) {
                            city = value;
                          },
                          validator: Validator.validateName,
                          keyboardType: TextInputType.text,
                          style: const TextStyle(
                              fontSize: 18.0, height: 1.5, color: Colors.black),
                          decoration: const InputDecoration(
                            labelText: 'City',
                            labelStyle: TextStyle(fontSize: 15),
                            hintText: "City",
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
                          keyboardType: TextInputType.text,
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
                      margin: EdgeInsets.all(10),
                      child: const Align(
                        alignment: Alignment.bottomCenter,
                        child: Text(
                          "Joining to loyalty club costs only 23.95, but brings you a lot of benefits with each subsequent projection!",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 20),
                        ),
                      ),
                    ),
                    Container(
                      margin: EdgeInsets.all(10),
                      child: Align(
                        alignment: Alignment.bottomCenter,
                        child: SizedBox(
                          width: 100,
                          child: ElevatedButton(
                            onPressed: () async {
                              try {
                                await makePayment();
                              } catch (err) {
                                showDialog(
                                  context: context,
                                  builder: (_) => AlertDialog(
                                    content: Text(err.toString()),
                                    actions: [
                                      TextButton(
                                          child: const Text("Ok"),
                                          onPressed: () => Navigator.pushNamed(
                                              context, MoviesListScreen.route))
                                    ],
                                  ),
                                );
                              }
                            },
                            child: const Text("Pay"),
                          ),
                        ),
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
