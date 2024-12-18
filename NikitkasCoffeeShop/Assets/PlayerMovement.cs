﻿using UnityEngine;

namespace Player
{
	public class PlayerMovement : MonoBehaviour
	{
		public Transform hand;

		public CharacterController controller;

		public float speed = 5f;
		public float gravity = -15f;

		Vector3 velocity;

		public Quests Quests;

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
				Application.Quit();

			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");

			Vector3 move = transform.right * x + transform.forward * z;

			controller.Move(move * speed * Time.deltaTime);

			velocity.y += gravity * Time.deltaTime;

			controller.Move(velocity * Time.deltaTime);
		}
	}
}