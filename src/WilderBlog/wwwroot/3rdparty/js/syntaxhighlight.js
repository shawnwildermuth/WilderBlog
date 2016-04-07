$(function () {
  // Add default coloring for old scripts
  $("code:not([class])").addClass("brush: csharp");
  $("pre:not([class])").addClass("brush: csharp");
  SyntaxHighlighter.defaults.tabSize = 2;
  SyntaxHighlighter.all();
});