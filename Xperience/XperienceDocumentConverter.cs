﻿using CMS.CustomTables;
using CMS.DataEngine;
using CMS.DocumentEngine;
using Statiq.Common;
using System.Collections.Generic;
using System.Linq;

namespace Kentico.Xperience.StatiqGenerator
{
    /// <summary>
    /// Helper class which converts Xperience objects to Statiq <see cref="IDocument"> objects,
    /// and vice-versa.
    /// </summary>
    public class XperienceDocumentConverter
    {
        public static BaseInfo ToBaseInfo(IDocument doc, string objectType)
        {
            var baseInfo = ModuleManager.GetObject(objectType);
            foreach (var prop in baseInfo.Properties)
            {
                baseInfo.SetValue(prop, doc.Get(prop));
            }

            return baseInfo;
        }

        public static IEnumerable<BaseInfo> ToBaseInfos(IEnumerable<IDocument> docs, string objectType)
        {
            return docs.Select(doc => ToBaseInfo(doc, objectType));
        }

        public static TItemType ToCustomTableItem<TItemType>(IDocument doc, string className)
            where TItemType : CustomTableItem, new()
        {
            var item = CustomTableItem.New<TItemType>(className, dataRow: null);
            foreach (var prop in item.Properties)
            {
                item.SetValue(prop, doc.Get(prop));
            }

            return item;
        }

        public static IEnumerable<TItemType> ToCustomTableItems<TItemType>(IEnumerable<IDocument> docs, string className) where TItemType : CustomTableItem, new()
        {
            return docs.Select(doc => ToCustomTableItem<TItemType>(doc, className));
        }

        public static IDocument FromBaseInfo(IExecutionContext context, BaseInfo info)
        {
            var metadata = new List<KeyValuePair<string, object>>();
            metadata.AddRange(info.Properties.Select(
                 key => new KeyValuePair<string, object>(key, info.GetValue(key))
             ));

            return context.CreateDocument(metadata);
        }

        public static IEnumerable<TPageType> ToTreeNodes<TPageType>(IEnumerable<IDocument> docs) where TPageType : TreeNode, new()
        {
            return docs.Select(doc => ToTreeNode<TPageType>(doc));
        }

        public static TPageType ToTreeNode<TPageType>(IDocument doc) where TPageType : TreeNode, new()
        {
            var node = TreeNode.New<TPageType>();
            foreach (var prop in node.Properties)
            {
                node.SetValue(prop, doc.Get(prop));
            }

            return node;
        }
    }
}
