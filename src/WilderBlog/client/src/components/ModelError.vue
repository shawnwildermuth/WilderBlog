<template>
  <span v-if="model.$invalid" class="text-danger">
    <slot>
      <ul class="list-unstyled">
        <li v-for="e in model.$errors" :key="e.$message">
          {{ e.$message }}
        </li>
      </ul>
    </slot>
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