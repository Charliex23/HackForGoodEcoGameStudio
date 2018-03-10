using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EmailPassword : MonoBehaviour
{

	private FirebaseAuth auth;
	public InputField UserNameInput, PasswordInput;
	public Button SignupButton, LoginButton;
	public Text ErrorText;

	void Start()
	{
		auth = FirebaseAuth.DefaultInstance;
		//Just an example to save typing in the login form
		UserNameInput.text = "";
		PasswordInput.text = "";

		SignupButton.onClick.AddListener(() => Signup(UserNameInput.text, PasswordInput.text));
		LoginButton.onClick.AddListener(() => Login(UserNameInput.text, PasswordInput.text));
	}


	public void Signup(string email, string password)
	{
		if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
		{
			//Error handling
			return;
		}

		auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
			{
				if (task.IsCanceled)
				{
					Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
					return;
				}
				if (task.IsFaulted)
				{
					Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
					if (task.Exception.InnerExceptions.Count > 0)
						UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
					return;
				}

				FirebaseUser newUser = task.Result; // Firebase user has been created.
				Debug.LogFormat("Firebase user created successfully: {0} ({1})",
					newUser.DisplayName, newUser.UserId);
				
				newUser.SendEmailVerificationAsync().ContinueWith(ntask => {
					if (ntask.IsCanceled) {
						Debug.LogError("SendEmailVerificationAsync was canceled.");
						return;
					}
					if (ntask.IsFaulted) {
						Debug.LogError("SendEmailVerificationAsync encountered an error: " + task.Exception);
						return;
					}

					Debug.Log("Email sent successfully.");
				});
				UpdateErrorMessage("Signup Success");
			});
	}

	private void UpdateErrorMessage(string message)
	{
		ErrorText.text = message;
		Invoke("ClearErrorMessage", 3);
	}

	void ClearErrorMessage()
	{
		ErrorText.text = "";
	}
	public void Login(string email, string password)
	{
		auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
			{
				if (task.IsCanceled)
				{
					Debug.LogError("SignInWithEmailAndPasswordAsync canceled.");
					return;
				}
				if (task.IsFaulted)
				{
					Debug.LogError("SignInWithEmailAndPasswordAsync error: " + task.Exception);
					if (task.Exception.InnerExceptions.Count > 0)
						UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
					return;
				}

				FirebaseUser user = task.Result;
				Debug.LogFormat("User signed in successfully: {0} ({1})",
					user.DisplayName, user.UserId);

				PlayerPrefs.SetString("LoginUser", user != null ? user.Email : "Unknown");
				SceneManager.LoadScene("Menu-Registro");
			});
	}
}