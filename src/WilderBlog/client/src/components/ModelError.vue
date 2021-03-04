<template>
  <span v-if="model.$invalid" class="inline-block">
    <ul class="flex text-red-600">
      <li v-for="e in model.$errors" :key="e.$message" class="mr-1">
        <em>
          <slot>{{ e.$message }}</slot>
        </em>
      </li>
    </ul>
  </span>
</template>
<script>
  export default {
    props: {
      model: {
        required: true,
      },
    },
  };
</script>