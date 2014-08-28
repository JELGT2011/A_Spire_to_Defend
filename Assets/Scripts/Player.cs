using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    protected int _gold;
    public int Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    protected int _playerNumber;
    public int PlayerNumber
    {
        get { return _playerNumber; }
        set { _playerNumber = value; }
    }

    protected TowerManager _towerManager;
    public TowerManager TowerManager
    {
        get { return _towerManager; }
        set { _towerManager = value; }
    }

    protected Vector2 _lastClickedCoordinates;
    public Vector2 LastClickedCoordinates
    {
        get { return _lastClickedCoordinates; }
        set { _lastClickedCoordinates = value; }
    }

    protected Ray _ray;
    public Ray Ray
    {
        get { return _ray; }
        set { _ray = value; }
    }

    protected GameObject _objectClicked;
    public GameObject ObjectClicked
    {
        get { return _objectClicked; }
        set { _objectClicked = value; }
    }

    protected GameObject _lastClickedObject;
    public GameObject LastClickedObject
    {
        get { return _lastClickedObject; }
        set { _lastClickedObject = value; }
    }

    protected RaycastHit _raycastHit;
    public RaycastHit RaycastHit
    {
        get { return _raycastHit; }
        set { _raycastHit = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        _towerManager = GetComponent<TowerManager>();
        _lastClickedCoordinates = new Vector2(0f, 0f);

        Debug.LogWarning("spawner still needs full implementation");
    }

    void Update()
    {
        // Determines what the player clicked on
        if (Input.GetMouseButtonDown(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _raycastHit))
            {
                _lastClickedObject = _raycastHit.transform.collider.gameObject;

                if (_lastClickedObject.tag == "Build Area")
                {
                    _lastClickedCoordinates = new Vector2((float) Mathf.RoundToInt(_raycastHit.point.x), (float)Mathf.RoundToInt(_raycastHit.point.z));
                }
                else if (_lastClickedObject.tag == "Tower")
                {

                }
                else if (_lastClickedObject.tag == "Enemy")
                {

                }
                else
                {

                }
            }
        }

        if ((Input.GetKeyDown(KeyCode.Keypad0)) && (_lastClickedObject != null))
        {
            if (_lastClickedObject.tag == "Build Area")
            {

            }
            else if (_lastClickedObject.tag == "Tower")
            {

            }
            else if (_lastClickedObject.tag == "Enemy")
            {

            }
        }

        if ((Input.GetKeyDown(KeyCode.Keypad1)) && (_lastClickedObject != null))
        {
            if (_lastClickedObject.tag == "Build Area")
            {
                _towerManager.CreateTower(Tower.TYPE.basic, _lastClickedCoordinates);
            }
            else if (_lastClickedObject.tag == "Tower")
            {
                _towerManager.DestroyTower(_lastClickedCoordinates);
            }
            else if (_lastClickedObject.tag == "Enemy")
            {

            }
        }

        if ((Input.GetKeyDown(KeyCode.Keypad2)) && (_lastClickedObject != null))
        {
            if (_lastClickedObject.tag == "Build Area")
            {

            }
            else if (_lastClickedObject.tag == "Tower")
            {

            }
            else if (_lastClickedObject.tag == "Enemy")
            {

            }
        }

        if ((Input.GetKeyDown(KeyCode.Keypad3)) && (_lastClickedObject != null))
        {
            if (_lastClickedObject.tag == "Build Area")
            {

            }
            else if (_lastClickedObject.tag == "Tower")
            {

            }
            else if (_lastClickedObject.tag == "Enemy")
            {

            }
        }
    }

    void OnGUI()
    {

    }
}
