$(function () {
  // Add default coloring for old scripts
  $("code:not([class])").addClass("brush: csharp");
  $("pre:not([class])").addClass("brush: csharp");
  SyntaxHighlighter.defaults.tabSize = 2;
  SyntaxHighlighter.defaults.fontSize = ".8em";
  var blocks = $("pre > code");
  for (var x = 0; x < blocks.length; ++x) SyntaxHighlighter.highlight(SyntaxHighlighter.defaults, blocks[x]);
});