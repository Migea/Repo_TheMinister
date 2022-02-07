using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleInformationUI : MonoBehaviour
{
    public Text text;
    public string AttackNAttack(string AttackA, string AttackB, int damage)
    {
        string output;
        if (damage > 0)
        {
            output = "˫��ͬʱ���й����˴ˣ�" + AttackA + "����һ���" + AttackB + "���" + Mathf.Abs(damage) + "���˺�";
        }
        else
        {
            output = "˫��ͬʱ���й����˴ˣ�" + AttackB + "����һ���" + AttackA + "���" + Mathf.Abs(damage)  + "���˺�";
        }
        text.text = output;
        return output;
    }

    public string AttackNDefence(string Attack, string Defence, int damageDeal)
    {
        string output;
        if (damageDeal > 0)
        {
            output = Defence + "��ͼ����" + Attack + "�Ĺ���������ʧ�ܣ��յ�" + damageDeal + "���˺�";
        }
        else
        {
            output = Defence + "������" + Attack + "�Ĺ�����" + Defence + "���" + Mathf.Abs(damageDeal) + "�㻤��";
        }
        text.text = output;
        return output;
    }

    public string AttackNAssasinate(string Attack, string Assassinate, int damageAttack, int damageAssassinate)
    {
        string output = Attack +"���湥������������Ϯ�̵�"
            +Assassinate+"�����"+ Mathf.Abs(damageAttack) +"�㱩���˺������ܵ������ԶԷ�Ϯ�̵�"
            + Mathf.Abs(damageAssassinate) +"���˺�";
        text.text = output;
        return output;
    }

    public string DefenceNDefence(string DefenceA, string DefenceB)
    {
        string output = "���ε��ǣ�˫��ͬʱ�����˷��أ������ 1 �㻤��";
        text.text = output;
        return output;
    }

    public string DefenceNAssassinate(string Defence, string Assassinate, int Damage)
    {
        string output = Assassinate+"������"+Defence+"�ķ�����Ϯ�̲����"+Damage+"���˺�";
        text.text = output;
        return output;
    }

    public string AssassinateNAssassinate(string AssassinateA, string AssassinateB, int DamageA, int DamageB)
    {
        string output = "˫���ܲ������Ϯ��Է������˻��˵�Ť����һ��"
            + AssassinateA + "�ܵ���" + Mathf.Abs(DamageB) + "���˺���" 
            + AssassinateB + "�ܵ���" + Mathf.Abs(DamageA) + "���˺�";
        text.text = output;
        return output;
    }
}
