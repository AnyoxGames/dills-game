13
4415226380289
405025353449472 1761863326977046900
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 7.0612893104553223,
    "Y": -11.3090057373046875
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405016984354189:1761863325027039100",
  "next_sibling": "405029716804173:1761863327993712800",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405025353687606:1761863326977101600",
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
  "aoid": "405025353811059:1761863326977130300",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405025353687606:1761863326977101600",
    "DefaultRenderer": "405025353864465:1761863326977142900",
    "DepletedRenderer": "405025353849028:1761863326977139200"
  }
},
{
  "cid": 5,
  "aoid": "405025353827356:1761863326977134100",
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
