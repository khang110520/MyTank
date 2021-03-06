using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    public TeamID Team;
    public int m_PlayerNumber = 1;              // Used to identify the different players.
    public Rigidbody m_Shell;                   // Prefab of the shell.
    public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
    public Slider m_AimSlider;                  // A child of the tank that displays the current launch force.
    public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
    public AudioClip m_ChargingClip;            // Audio that plays when each shot is charging up.
    public AudioClip m_FireClip;                // Audio that plays when each shot is fired.
    public float m_MinLaunchForce = 15f;        // The force given to the shell if the fire button is not held.
    public float m_MaxLaunchForce = 30f;        // The force given to the shell if the fire button is held for the max charge time.
    public float m_MaxChargeTime = 0.75f;       // How long the shell can charge for before it is fired at max force.

    private string m_FireButton;                // The input axis that is used for launching shells.
    private float m_CurrentLaunchForce;         // The force that will be given to the shell when the fire button is released.
    private float m_ChargeSpeed;                // How fast the launch force increases, based on the max charge time.
    private bool m_Fired;                       // Whether or not the shell has been launched with this button press.

    private float interval;

    public BaseShoot[] listShoot;
    private BaseShoot currentShoot;
    private int shootIndex;

    public BaseBullet[] listBullet;
    public BaseBullet currentBullet;
    private int shellIndex;

    public bool IsCanFire;

    private void Awake()
    {
        currentShoot = listShoot[0];
        currentBullet = listBullet[0];

        IsCanFire = true;
    }

    private void OnEnable()
    {
        // When the tank is turned on, reset the launch force and the UI
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
        // The fire axis is based on the player number.
        m_FireButton = "Fire" + m_PlayerNumber;

        // The rate that the launch force charges up is the range of possible forces by the max charge time.
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_PlayerNumber == 1)
        {
            ChangeShoot();
        }

        if (Input.GetKeyDown(KeyCode.P) && m_PlayerNumber == 2)
        {
            ChangeShoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && m_PlayerNumber == 1)
        {
            ChangeEffect();
        }

        if (Input.GetKeyDown(KeyCode.O) && m_PlayerNumber == 2)
        {
            ChangeEffect();
        }

        currentShoot.DoUpdate(m_FireTransform, m_CurrentLaunchForce);

        if (interval > 0)
        {
            interval -= Time.deltaTime;
            return;
        }

        // The slider should have a default value of the minimum launch force.
        m_AimSlider.value = m_MinLaunchForce;

        // If the max force has been exceeded and the shell hasn't yet been launched...
        if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
        {
            // ... use the max force and launch the shell.
            m_CurrentLaunchForce = m_MaxLaunchForce;
            Fire();
        }
        // Otherwise, if the fire button has just started being pressed...
        else if (Input.GetButtonDown(m_FireButton))
        {
            // ... reset the fired flag and reset the launch force.
            m_Fired = false;
            m_CurrentLaunchForce = m_MinLaunchForce;

            // Change the clip to the charging clip and start it playing.
            m_ShootingAudio.clip = m_ChargingClip;
            m_ShootingAudio.Play();
        }
        // Otherwise, if the fire button is being held and the shell hasn't been launched yet...
        else if (Input.GetButton(m_FireButton) && !m_Fired)
        {
            // Increment the launch force and update the slider.
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

            m_AimSlider.value = m_CurrentLaunchForce;
        }
        // Otherwise, if the fire button is released and the shell hasn't been launched yet...
        else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
        {
            // ... launch the shell.
            Fire();
        }
    }

    private void Fire()
    {
        if (IsCanFire)
        {
            interval = currentShoot.interval;
            currentShoot.Fire(m_FireTransform, m_CurrentLaunchForce, m_MinLaunchForce, Time.deltaTime, Team, currentBullet, m_Fired, m_ShootingAudio, m_FireClip);
            m_Fired = true;
        }
    }

    public void StopFire()
    {
        IsCanFire = false;
    }

    public void ContinueFire()
    {
        IsCanFire = true;
    }
    
    private void ChangeShoot()
    {
        int newShootIndex = (shootIndex + 1) % listShoot.Length;
        currentShoot = listShoot[newShootIndex];
        shootIndex = newShootIndex;
    }

    public void ChangeEffect()
    {
        int newShootIndex = (shellIndex + 1) % listBullet.Length;
        currentBullet = listBullet[newShootIndex];
        shellIndex = newShootIndex;
    }
}