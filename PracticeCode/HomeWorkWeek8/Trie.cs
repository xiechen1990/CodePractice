﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkWeek8
{
 
    class Trie
    {
        private Trie[] Children;
        private bool isEnd;

        
        public Trie()
        {
            this.Children = new Trie[26];
            isEnd = false;
        }

        public void insert(string word)
        {
            Trie node = this;
            for(int i = 0; i < word.Length; i ++)
            {
                char  ch = word[i];
                int index = ch - 'a';

                if (node.Children[index] == null)
                {
                    node.Children[index] = new Trie();
                }
                node = this.Children[ch];
            }
            isEnd = true;
        }


        public bool serach(string word)
        {
            Trie node = serchPre(word);
            return node != null && node.isEnd;
        }


        private Trie serchPre(string word)
        {
            Trie node = this;
            for(int i = 0; i < word.Length; i ++)
            {
                char ch = word[i];
                int index = ch - 'a';
                if(node.Children[index] != null)
                {
                    node = node.Children[index];
                }
                else
                {
                    return null;
                }
            }
            return node;
        }

    }




}
