13
3448858738689
404874710300326 1761863291877037300
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -15.3655414581298828,
    "Y": 6.2005915641784668
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404871277261252:1761863291077135800",
  "next_sibling": "404877285442014:1761863292477047900",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404874710563142:1761863291877097700",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404874710684144:1761863291877125900",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404874710563142:1761863291877097700",
    "DefaultRenderer": "404874710733637:1761863291877137400",
    "DepletedRenderer": "404874710716050:1761863291877133300"
  }
},
{
  "cid": 5,
  "aoid": "404874710696528:1761863291877128700",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
