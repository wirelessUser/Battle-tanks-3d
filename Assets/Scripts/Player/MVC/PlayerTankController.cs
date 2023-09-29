using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController
{

    public PlayerTankModel model;
    public PlayerTankView view;
    public Rigidbody rb;

    private Transform tankTransform;
    public void PlayerTankControllerSetting(PlayerTankModel _model, PlayerTankView _view, PlayerTankView _playerView)
    {
        model = _model;

        view = _playerView;

        model.SetController(this);

        model.SetPlayerTankModel(view.dataSo);

        rb = _playerView.GetComponent<Rigidbody>();

        _playerView.SetController(this);
        _playerView.gameObject.name = model.name;
        tankTransform = view.gameObject.transform;
    }



    public void Move(float moveDir)
    {



        rb.velocity = view.transform.forward * moveDir * model.movementSpeed * Time.deltaTime;


    }
    public void Rotation(float rotateDir)
    {

        Quaternion rotationAngle = Quaternion.Euler(new Vector3(0f, rotateDir, 0f));


        rb.MoveRotation(rb.rotation * rotationAngle);

    }






    public void FireBulletLowDamage(Transform spawnPoint)
    {
        BulletService.Instance.SpawnBullet(view.gameObject, BulletCategory.LowDamage, model.playerSo.bulletPool[0] - 1, model.id, spawnPoint, tankTransform, BulletType.PlayerBullet);
    }

    public void FireBulletHighDamage(Transform spawnPoint)
    {
        BulletService.Instance.SpawnBullet(view.gameObject, BulletCategory.HighDamage, model.playerSo.bulletPool[1] - 1, model.id, spawnPoint, tankTransform, BulletType.PlayerBullet);
    }

    public void FireBulletOneShotDamage(Transform spawnPoint)
    {
        BulletService.Instance.SpawnBullet(view.gameObject, BulletCategory.OneSHotDamage, model.playerSo.bulletPool[2] - 1, model.id, spawnPoint, tankTransform, BulletType.PlayerBullet);
    }



}
