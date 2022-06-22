using UnityEngine;
using System.Collections;




public class Flashlight_PRO : MonoBehaviour 
{
	[Space(10)]
	[SerializeField()] GameObject Lights; // all light effects and spotlight
	[SerializeField()] AudioSource switch_sound; // audio of the switcher
	[SerializeField()] ParticleSystem dust_particles; // dust particles

	[SerializeField()] GameObject Mask;



	private Light spotlight;
	private Material ambient_light_material;
	private Color ambient_mat_color;
	private bool is_enabled = false;

	private Transform m_transform;







	// Use this for initialization
	void Start () 
	{
		m_transform = transform;

		// cache components
		spotlight = Lights.transform.Find ("Spotlight").GetComponent<Light> ();
		ambient_light_material = Lights.transform.Find ("ambient").GetComponent<Renderer> ().material;
		ambient_mat_color = ambient_light_material.GetColor ("_TintColor");
	}

    private void FixedUpdate()
    {
		if (!is_enabled) return;

		Vector3 origin = m_transform.position; // 原点
		Vector3 direction = m_transform.right; // X軸方向を表すベクトル
		Ray ray = new Ray(origin, direction); // Rayを生成
		Debug.DrawRay(ray.origin, ray.direction * 30, Color.red); // 長さ３０、赤色で５秒間可視化

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 30.0f)) // もしRayを投射して何らかのコライダーに衝突したら
		{
			string name = hit.collider.gameObject.name; // 衝突した相手オブジェクトの名前を取得
														//Debug.Log(name); // コンソールに表示

			float maskScale = Vector3.Distance(hit.point, origin) * Mathf.Tan(Mathf.PI / 12) / m_transform.localScale.y;
			Mask.transform.SetPositionAndRotation(hit.point, Quaternion.Euler(0, hit.transform.eulerAngles.y - 90, 90));
			Mask.transform.localScale = new Vector3(maskScale, 0.05f, maskScale);

        }
        else
		{
			float maskScale = Mathf.Tan(Mathf.PI / 12);
			Mask.transform.SetPositionAndRotation(origin, Quaternion.Euler(m_transform.rotation.x, m_transform.rotation.y, m_transform.rotation.y + 90));
			Mask.transform.localScale = new Vector3(maskScale, 0.05f, maskScale);
		}
	}




    /// <summary>
    /// changes the intensivity of lights from 0 to 100.
    /// call this from other scripts.
    /// </summary>
    public void Change_Intensivity(float percentage)
	{
		percentage = Mathf.Clamp (percentage, 0, 100);


		spotlight.intensity = (8 * percentage) / 100;

		ambient_light_material.SetColor ("_TintColor", new Color(ambient_mat_color.r , ambient_mat_color.g , ambient_mat_color.b , percentage/2000)); 
	}




	/// <summary>
	/// switch current state  ON / OFF.
	/// call this from other scripts.
	/// </summary>
	public void Switch()
	{
		is_enabled = !is_enabled; 

		Lights.SetActive (is_enabled);
		Mask.SetActive (is_enabled);

		if (switch_sound != null)
			switch_sound.Play ();
	}





	/// <summary>
	/// enables the particles.
	/// </summary>
	public void Enable_Particles(bool value)
	{
		if(dust_particles != null)
		{
			if(value)
			{
				dust_particles.gameObject.SetActive(true);
				dust_particles.Play();
			}
			else
			{
				dust_particles.Stop();
				dust_particles.gameObject.SetActive(false);
			}
		}
	}


}
