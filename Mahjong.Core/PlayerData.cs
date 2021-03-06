using System;
using System.Collections.Generic;
using System.Text;

namespace Mahjong.Core
{
    public class PlayerData
    {
        private Group m_hand = new Group();
        private Group m_cemetery = new Group();
        private List<Group> m_exposed = new List<Group>();
        private Tile m_rejected = null;
        private int m_position;
        private String m_name;
        
        public PlayerData(String name)
        {
            m_name = name;
        }

        public String GetName()
        {
            return m_name;
        }

        public void SetName(String name)
        {
            m_name = name;
        }

        public Group GetHand()
        {
            return m_hand;
        }

        public bool AddHand(Tile add)
        {
            m_hand.Add(add);
            return true;
        }

        public bool RemoveHand(Tile del)
        {
            return m_hand.Remove(del);
        }

        public Group GetCemetery()
        {
            return m_cemetery;
        }
        public bool AddCemetery(Tile add)
        {
            m_cemetery.Add(add);
            return true;
        }
        public List<Group> GetExposed()
        {
            return m_exposed;
        }
        public bool AddExposed(Group exposed)
        {
            m_exposed.Add(exposed);
            return true;
        }

        public Tile GetRejected()
        {
            return m_rejected;
        }

        public bool AddRejected(Tile add)
        {
            m_rejected = add;
            return true;
        }
        public int GetPosition()
        {
            return m_position;
        }

        public bool SetPosition(int p)
        {
            m_position = p;
            return true;
        }

        public void Reset()
        {
            m_hand = new Group();
            m_cemetery = new Group();
            m_exposed.Clear();
            m_rejected = null;
        }

    }
}

