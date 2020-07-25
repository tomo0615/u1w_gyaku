﻿using UnityEngine;
using UnityEngine.AI;

namespace Unit
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(UnitAttacker))]
    public abstract class BaseUnit : MonoBehaviour, IAttackable
    {
        private UnitMover _unitMover;

        private UnitAttacker _unitAttacker;

        private TargetSetter _targetSetter;

        [SerializeField]
        private int hitPoint = 1;

        [SerializeField]
        private float moveSpeed = 10;　//ToDo：Navimeshと同期

        [SerializeField]
        private UnitActionState currentState = UnitActionState.Move;

        [SerializeField]
        private Animator _animator = null;

        private Transform attackTarget = null;

        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _unitMover = new UnitMover(transform, GetComponent<Rigidbody>());

            _unitAttacker = GetComponent<UnitAttacker>();

            _targetSetter = new TargetSetter(transform);

            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // 不要に感じる
        private void Start()
        {
            if (attackTarget == null)
            {
                attackTarget = _targetSetter.SetNearestTarget();
            }
            _navMeshAgent.SetDestination(attackTarget.position);
        }

        private void Update()
        {
        
            if(attackTarget == null)
            {
                attackTarget = _targetSetter.SetNearestTarget();
                _navMeshAgent.SetDestination(attackTarget.position);
            }
        
            UpdateAnimation();
        
            //Action

            // switch の方が好き
            if (currentState == UnitActionState.Move)
            {
                //_unitMover.MoveToTartget(attackTarget, moveSpeed);
            }
            else if(currentState == UnitActionState.Attack)
            {
                _unitMover.StopMove();

                _unitAttacker.AttackToTarget();
            }
            else
            {
                return;
            }
        }

        private void UpdateAnimation()
        {
            //距離でState変更
            if (_unitAttacker.IsAttackToTarget(attackTarget))
            {
                currentState = UnitActionState.Attack;
            }
            else
            {
                currentState = UnitActionState.Move;
            }

            _animator.Play(currentState.ToString());
        }

        public void SetTarget(Transform target)
        {
            attackTarget = target;
        }

        public void Attacked(int damageValue)
        {
            hitPoint -= damageValue;

            if (hitPoint > 0) return;
        
            GameEffectManager.Scripts.GameEffectManager.Instance
                .OnGenelateEffect(transform.position, EffectType.UnitDead);

            UnitManager.Instance.RemoveUnitList(this);

            gameObject.SetActive(false);
        }
    }
}
